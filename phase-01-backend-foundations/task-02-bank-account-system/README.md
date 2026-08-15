# TechMaster Bank System



## 1. Project Overview



TechMaster Bank System is a console-based banking mini-system implemented in C# as part of TechMaster Academy Phase 01 Task 02. The application provides a simple in-memory banking domain for employees to manage customer accounts and perform basic financial operations from a console UI.



Business purpose (implemented):



* Employees can create customer bank accounts.

* Employees can deposit money.

* Employees can withdraw money.

* Employees can transfer money between accounts.

* Employees can view account details.

* Employees can view transaction history.

* Employees can view all accounts.



## 2. Business Requirements



Main business rules implemented in the application (as enforced in code):



* Account numbers must be unique (BankService.AccountCreation throws if duplicate).

* Customer information (full name, email, phone) is required (validated in UI before creation).

* Account type must be a valid enum value (checked in UI using Enum.TryParse).

* Deposit amount must be positive (BankAccount.Deposit returns false if amount <= 0).

* Withdraw amount must be positive (BankAccount.WithDraw returns false if amount <= 0).

* Withdraw amount cannot exceed the account balance (BankAccount.WithDraw returns false).

* Accounts must exist before financial operations (BankService checks for accounts and throws if not found).

* Inactive accounts cannot perform financial operations (BankService checks IsActive before operations).

* Source and destination accounts cannot be the same during transfer (BankService throws if same instance).

* Successful financial operations create transaction records (Transaction objects are added to account.Transactions).

* Transaction.BalanceAfterTransaction is recorded (Transaction.SetBalanceAfterTransaction is called after operations).



## 3. Features



| Feature                  | Description | Status    |

| ------------------------ | ----------- | --------- |

| Create Customer Account  | Create a Customer and associated BankAccount with a unique account number. | Completed |

| Deposit Money            | Deposit positive amounts into an existing active account and record a transaction. | Completed |

| Withdraw Money           | Withdraw positive amounts up to the available balance and record a transaction. | Completed |

| Transfer Money           | Transfer money between two different active accounts (withdraw then deposit) and record transaction(s). | Completed |

| View Account Details     | Show stored account and customer information and current balance. | Completed |

| View Transaction History | List transactions for a given account (ordered by date desc). | Completed |

| View All Accounts        | List all created accounts with basic details and status. | Completed |



## 4. Project Structure



Files and important classes (paths are relative to project root):



* Bank Account System/Models/Customer.cs

&#x20; - Class: Customer

&#x20; - Holds CustomerId, FullName, Email, PhoneNumber, CreatedAt.



* Bank Account System/Models/BankAccount.cs

&#x20; - Class: BankAccount

&#x20; - Holds AccountNumber, Customer, Balance, AccountType, CreatedAt, IsActive, Transactions.

&#x20; - Methods: Deposit(decimal), WithDraw(decimal), UpdateBalance(...), AddTransaction(...).



* Bank Account System/Models/Transaction.cs

&#x20; - Class: Transaction

&#x20; - Holds TransactionId, FromAccountNumber, ToAccountNumber, Amount, TransactionType, TransactionDate, Description, BalanceAfterTransaction.

&#x20; - Method: SetBalanceAfterTransaction(decimal).



* Bank Account System/Models/AccountType.cs

&#x20; - Enum: AccountType (Savings, Current).



* Bank Account System/Models/TransactionType.cs

&#x20; - Enum: TransactionType (Deposit, withDraw, Transfer).



* Bank Account System/Services/BankService.cs

&#x20; - Static service class that coordinates account creation, deposits, withdrawals, transfers, viewing account details, viewing transaction history, and listing accounts.

&#x20; - In-memory storage: public static List<Customer> Customers and public static List<BankAccount> BankAccounts.



* Bank Account System/UI/ConsoleMenu.cs

&#x20; - Console menu rendering (ShowMenu).



* Program.cs

&#x20; - Console UI flow: reads user input, validates, constructs Transaction or Customer objects and calls BankService methods.



## 5. OOP Concepts Demonstrated



The project demonstrates common OOP concepts with concrete examples from the codebase:



* Encapsulation

&#x20; - Example: BankAccount.Balance has a private setter; it is changed only via Deposit/WithDraw/UpdateBalance.



* Classes and Objects

&#x20; - Example: Customer, BankAccount, Transaction are domain classes instantiated in Program and BankService.



* Constructors

&#x20; - Example: new BankAccount(accountNumber, customer, accountType) initializes account state (Balance = 0, IsActive = true).



* Properties

&#x20; - Example: Customer.FullName { get; private set; } — read-only from outside after construction.



* Access modifiers

&#x20; - Example: public for service surface, private setters for protecting state, static for BankService storage.



* Private setters

&#x20; - Example: Transaction.BalanceAfterTransaction uses a private setter and is only changed by SetBalanceAfterTransaction.



* Methods and behavior

&#x20; - Example: BankAccount.Deposit and BankAccount.WithDraw implement validation and call UpdateBalance to change Balance.



* Enums

&#x20; - Example: AccountType and TransactionType used to restrict allowed values for account and transaction kinds.



* Separation of responsibilities

&#x20; - Example: UI (Program.cs + ConsoleMenu) handles input and display; BankService coordinates business rules and data; models encapsulate state and behavior.



* Composition / object relationships

&#x20; - Example: BankAccount contains a Customer reference and a List<Transaction> for related transactions.



## 6. Business Logic



Where business rules are implemented:



* BankAccount

&#x20; - Responsible for account-level operations such as Deposit, WithDraw and UpdateBalance. It enforces amount rules (positive amounts; withdraw <= balance) and updates the Balance.



* BankService

&#x20; - Coordinates higher-level banking operations: account creation, transfer orchestration, validations across accounts (existence, activity, same-account checks), and transaction recording.



* Program / UI

&#x20; - Responsible for user interaction: reading input, simple input validation (non-empty strings, numeric parsing, enum parsing) and calling service methods. UI does not contain persistence or the core business logic.



Keeping business logic in BankService/BankAccount (not in the menu) improves testability, maintainability, and separation of concerns.



## 7. Transaction System



Transaction model (Bank Account System/Models/Transaction.cs) important properties:



* TransactionId — string (GUID generated in constructor).

* FromAccountNumber / ToAccountNumber — strings (nullable for some operations).

* Amount — decimal.

* TransactionType — TransactionType enum.

* TransactionDate — DateTime (set to UTC now by default).

* Description — optional string.

* BalanceAfterTransaction — decimal (recorded by calling SetBalanceAfterTransaction).



How transactions are created and added:



* Program constructs a Transaction and passes it to BankService.Transfer (the single method used for Deposit, Withdraw, and Transfer operations).

* BankService performs the requested action (deposit, withdraw or transfer). When an operation succeeds it calls transaction.SetBalanceAfterTransaction(currentBalance) and then adds the same Transaction object to the involved account(s) via BankAccount.AddTransaction(transaction).



Note about transfers and BalanceAfterTransaction:



* Transfers reuse a single Transaction instance for both source and destination accounts and add that same object to both accounts' Transactions lists.

* The implementation calls SetBalanceAfterTransaction twice in Transfer (first with fromAccount.Balance, then with toAccount.Balance). Because SetBalanceAfterTransaction stores a single BalanceAfterTransaction value, the second call overwrites the first. As a result the saved BalanceAfterTransaction will end up equal to the destination account balance at the end of the transfer. This is the current behavior in code.



## 8. Validation & Error Handling



Validation and error handling implemented in the project (actual checks from code):



* Missing account

&#x20; - BankService throws InvalidOperationException when account(s) involved in a transaction are not found.



* Invalid / Negative / Zero amount

&#x20; - BankAccount.Deposit and BankAccount.WithDraw return false when amount <= 0; BankService translates these into InvalidOperationException with messages for the caller.



* Insufficient balance

&#x20; - BankAccount.WithDraw returns false if amount > Balance; BankService throws an InvalidOperationException for transfer/withdraw when withdraw fails.



* Duplicate account number

&#x20; - AccountCreation checks existing BankAccounts and throws InvalidOperationException("Account already exists.") when found.



* Inactive account

&#x20; - BankService verifies account.IsActive before performing deposit/withdraw/transfer and throws InvalidOperationException when not active.



* Same-account transfer

&#x20; - BankService throws InvalidOperationException("Cannot transfer to the same account.") when source and destination refer to the same BankAccount instance.



* Invalid account type

&#x20; - The console UI enforces AccountType parsing using Enum.TryParse and requests re-entry until a valid value is provided.



* Invalid menu option

&#x20; - Program reads option using int.TryParse in a loop; unrecognized numeric options produce a default message.



Exceptions from BankService are caught at the UI layer (Program.cs) and displayed to the user.



## 9. Application Flow (Console Menu)



Menu options (as shown in ConsoleMenu.ShowMenu and Program.cs):



1. Create Customer Account

&#x20;  - UI: reads full name, email, phone, account type, and account number; constructs Customer and calls BankService.AccountCreation.

2. Deposit Money

&#x20;  - UI: asks for To Account Number, amount and description; creates a Transaction with TransactionType.Deposit and calls BankService.Transfer (which handles deposits).

3. Withdraw Money

&#x20;  - UI: asks for From Account Number, amount and description; creates a Transaction with TransactionType.withDraw and calls BankService.Transfer (which handles withdrawals).

4. Transfer Money

&#x20;  - UI: asks for From and To account numbers, amount and description; creates a Transaction with TransactionType.Transfer and calls BankService.Transfer.

5. View Account Details

&#x20;  - UI: asks for account number and calls BankService.ViewAccountDetails to print account and customer info.

6. View Transaction History

&#x20;  - UI: asks for account number and calls BankService.TransactionHistory to print transactions in descending date order.

7. View All Accounts

&#x20;  - UI: calls BankService.ViewAllAccounts and prints summary information for each account.

8. Exit

&#x20;  - UI: exits the application.



## 10. Example Usage (demonstration)



Example steps (values are illustrative):



1) Create two accounts



* Inputs (Account A):

&#x20; - Full Name: Alice Example

&#x20; - Email: alice@example.com

&#x20; - Phone: 123456

&#x20; - Account Type: 1 (Savings)

&#x20; - Account Number: A100



* Inputs (Account B):

&#x20; - Full Name: Bob Example

&#x20; - Email: bob@example.com

&#x20; - Phone: 234567

&#x20; - Account Type: 2 (Current)

&#x20; - Account Number: B200



2) Deposit money to Account A



* To Account Number: A100

* Amount: 1000

* Description: Initial deposit



3) Withdraw from Account A



* From Account Number: A100

* Amount: 200

* Description: ATM withdrawal



4) Transfer from Account A to Account B



* From Account Number: A100

* To Account Number: B200

* Amount: 300

* Description: Payment to Bob



5) View Account Details



* Choose option 5 and enter account number (A100 or B200) to see current balance and customer info.



6) View Transaction History



* Choose option 6 and enter account number to see recorded transactions and Balance After values (note transfer BalanceAfterTransaction reflects the destination account balance as implemented).



## 11. Testing Scenarios



| Test Case             | Input / Scenario | Expected Result |

| --------------------- | ---------------- | --------------- |

| Valid Deposit         | Deposit 500 to existing active account | Success; transaction recorded; account balance increased by 500 |

| Zero Deposit          | Deposit 0 | Rejected (Deposit returns false -> BankService throws) |

| Negative Deposit      | Deposit -100 | Rejected (Deposit returns false -> BankService throws) |

| Missing Account       | Deposit to non-existing account | BankService throws InvalidOperationException (account not found) |

| Valid Withdraw        | Withdraw 100 from account with balance >=100 | Success; transaction recorded; balance decreased |

| Insufficient Balance  | Withdraw amount greater than balance | Rejected (WithDraw returns false -> BankService throws) |

| Same Account Transfer | Transfer from A to A | Rejected: BankService throws "Cannot transfer to the same account." |

| Valid Transfer        | Transfer 50 from A to B where A has sufficient funds | Success; both accounts receive the same Transaction object; destination balance recorded in BalanceAfterTransaction (current implementation) |



These tests reflect the validation and exception-handling implemented in the code.



## 12. Technologies Used



* C# (classes, enums, properties)

* .NET (Console application targeting .NET 10)

* Console Application

* LINQ (used for Any(), OrderByDescending())

* OOP principles



## 13. How to Run



From repository root you can run the console app with dotnet CLI. Example (PowerShell):



```powershell
dotnet run --project "phase-01-backend-foundationstask-02-bank-account-system/task-02-bank-account-system.csproj"

```



Alternatively, open the project in Visual Studio and run the project.



## 14. Learning Outcomes



This project demonstrates key backend and OOP concepts:



* Modeling real-world entities (Customer, BankAccount, Transaction).

* Encapsulating sensitive state by using private setters to protect balance and identifiers.

* Protecting account balance from direct modification (changes happen via methods).

* Separating UI (Program/ConsoleMenu) from business logic (BankService) and domain models.

* Validating financial operations (positive amounts, sufficient balance, account existence, activity).

* Managing relationships between Customer, BankAccount and Transaction.

* Handling invalid business operations via exceptions and return values.



## 15. Project Limitations / Future Improvements



Possible improvements (not implemented in this project):



* Persistent storage (database) instead of in-memory lists.

* Authentication and authorization for employees/users.

* Stronger validation for email and phone (format checks).

* More robust transaction model to record both source and destination balances separately (separate TransferOut/TransferIn records).

* Repository pattern and Dependency Injection for testability.

* Unit tests to cover service and model behaviour.

* Exposing functionality as an ASP.NET Core Web API for remote clients.

* Structured logging and error handling.



---



This README documents the current implementation exactly as found in the source. For questions about specific code locations, see the files inside the "Bank Account System" folder.






# Gilded Rose Inventory System

This is a console application for managing the inventory of a small inn called Gilded Rose. The application simulates the daily updates to the quality and sell-in values of different items in the inventory based on specific rules.

## Compilation and Execution

### Prerequisites
- .NET Core SDK (download from https://dotnet.microsoft.com/download)
- Git (optional, for cloning the repository)

### Steps to Compile and Run

1. Clone the repository from GitHub:
   ```
   git clone https://github.com/burgua/gilded-rose-app.git
2. Run the application:
   ```
   dotnet run
This will compile and execute the Gilded Rose inventory system, displaying the updated values for each item.

3. To run the unit tests:
   ```
   dotnet test
This will run the unit tests to ensure the correctness of the code logic and functionality.

### Approval Tests

The Approval tests work by comparing the system output against "approved" (expected outcome) files. If the system's output deviates from the approved files, the tests fail.
The application includes an 'ApprovalTest.ThirtyDays.approved.txt' file. This file indicates the expected state of the inventory over thirty days.

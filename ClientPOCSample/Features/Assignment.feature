Feature: Assignment Automation
	Automation website

@Register
Scenario: Register as a new user
	Given I launch the application
	   | Browser |
	   | chrome  |

Scenario: Verify TextBox functionality
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then  Text Box (Verification of the details post submission)

Scenario: Verify CheckBox functionality
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then   Check Box (Verification of the selected items)

Scenario: Verify WebTables functionality
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then   Web Tables (Edit the contents of the Web Table)	  
	
Scenario: Verify Buttons functionality
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then  Buttons (Verify the button selected by the message displayed on button click)
	
Scenario: Verify upload and download functionality
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then  Upload and Download (Implement logic to perform the required actions)
	
Scenario: Verify Alerts Frame Windows functionality
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then Automation of Alerts, Frame & Windows

Scenario: Enter Invalid Data
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then Enter the invalid data

Scenario: Enter Valid data 
	Given I launch the application
	   | Browser |
	   | chrome  |
	Then Then Enter the valid data
	


# Phone Number and Email Confirmation

## Description 
New users must confirm their email or phone number by answering a simple challenge with their respective info or device.

## Access
Everyone (Public)

## Business Rules
1. Once a new user is passed through Sinuka.Web.Accounts, system must send an email or message with a unique PIN/Code attached
2. User enters the given PIN/Code to the system
3. If the system doesn't recognize the PIN/Code, the user is notified to try again.
4. Otherwise, if the system recognize the PIN/Code as valid, flag the email or phone number as valid.

## Remarks
- This business flow is the same for phone number and email

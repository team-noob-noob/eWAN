# Account Lockout
## Description
User should be unable to login to the account after a specified count of failure to provide credentials.

## Access
Everyone (Public)

## Business Rules
1. After 3 failures to login to account. If username has an existing account, disable login for 15 minutes.
    1. After 15 minutes, account should be enabled for login
2. After 3 failures to login again (6 in total), disable login for 1 hour
3. After 3 failures to login again (9 in total), disable until enabled manually
    1. User should now contact admin to re-enable account manually

## Remarks
- Should a flag that allows to disable permanent disable, instead will be replaced by 24 hours. Every subsequent 3 failures without successfully logging in will always be 24 hours.
- Should reset the count to 0 after the login successfully logins

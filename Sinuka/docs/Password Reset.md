# Password Reset

## Description
User should be able to change/update/reset their password if the user isn't able to access their account

## Access
Everyone (Public)

## Business Rules
1. System requires the user to enter their account's username and email 
2. If username and email are not valid, system will notify the user that their credentials isn't valid
3. System should send an email to the user to recieve the new password
4. Once the user has entered their new password, system should store the new password and notify the user's email that the password has changed.

## Remarks
- Written the email, there should be an option to lockout their account incase there password reset request isn't theirs.

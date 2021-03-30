# Features
- It should authenticate users
- Handle n attempts account locking
- Handle password resets
    - in addition, it should send it to the users email
- Handle role changes in users
- Handle email confirmations
- Handle phone number confirmations
- Handle multiple clients and multiple scopes non-programmatically (Identity Server specific)

# Limitations
- Sinuka shouldn't be able to create (register) new users
    - An endpoint would be exposed to allow Sinuka to accept new users
        - Delegated to another Web Project to allow for internal access only
- Sinuka shouldn't be able to store personal details of users
    - It will only store username, password and emails

# Integrations
- Elastic Stack for Logging and Monitoring

# Remarks
- Admin and Public are on separate web projects

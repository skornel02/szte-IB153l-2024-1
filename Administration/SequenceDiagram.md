# Sequence diagram

> This is a Mermaid diagram. It is a simple way to create diagrams in markdown.
> For more information, see the [Mermaid documentation](https://mermaid.js.org/syntax/sequenceDiagram.html).
> [Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)

```mermaid
sequenceDiagram
    autonumber

    actor User
    participant Webshop as RegisterPage
    participant Model as RegisterModel
    participant Database as DbContext

    User->>+Webshop: Opens registration page
    Webshop-->>User: Sends registration form

    loop Until form is valid

        loop Enters email
            User->>Webshop: sends e-mail address
            Webshop->>Model: calls method to check if e-mail is already in use
            Model->>+Database: Exists query
            Database-->>-Model: Query result
            Model-->>Webshop: Returns whether e-mail is already in use
            Webshop-->>User: Returns whether e-mail is already in use
        end

        loop Enters passwords
            User->>User: Validate passwords
        end
    end

    User->>Webshop: Submits valid form
    Webshop->>Model: Calls method to insert user
    Model->>+Database: Insert user
    Database-->>-Model: Insertion result
    Model-->>Webshop: Returns insertion result
    Webshop-->>-User: Redirects to login page or shows error
```

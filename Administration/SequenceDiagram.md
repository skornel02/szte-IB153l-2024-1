# Sequence diagram

> This is a Mermaid diagram. It is a simple way to create diagrams in markdown.
> For more information, see the [Mermaid documentation](https://mermaid.js.org/syntax/sequenceDiagram.html).
> [Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)

```mermaid
sequenceDiagram
    autonumber

    participant Payment provider
    actor Customer
    participant Webshop
    participant Order Management System

    Customer->>+Webshop: Place order

    Webshop->>+Payment provider: Create payment request
    Payment provider-->>Webshop: Payment url

    Webshop-->>Customer: Payment url

    Customer->>Payment provider: Pays
    Payment provider-->>Customer: Redirects to order stats
    
    Payment provider->>-Webshop: Payment confirmation

    Webshop->>-Order Management System: Reserve order items


    loop Check order status
        Customer->>+Webshop: Request order status
        Webshop-->>-Customer: Order status
    end
```

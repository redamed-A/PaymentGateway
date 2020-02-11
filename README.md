# PaymentGateway Api .Net Core 3.0 with CQRS and Solid patterns

This is a solution to simulate a payment process, its include an APi .net core and a ReactJS client to consume this API.
The API will allow a mechant to offer for their shoppers a way to pay for their product.

## Packagages:

  ####    - .Net core 3.0
  ####    - MediatR 8.0
  ####    - EntityFrameworkCore.SqlServer 
  ####    - Swagger (Swashbuckle) 5.0
  ####    - Microsoft.Extensions.Logging.Debug 3.0
  ####    - Automapper 7.0


## Installation:
- Firt you need to create a database "PaymentDB" for this solution or another one and chnage the configuration in  appsettings.json.
- Run the "Create_Payment_Table" script to create the table 

## How to make it run :
## 1- Test the API with Swagger
- In the APi project there Swagger configured so to test the API methods you can use it directly from this URL : http://localhost:3501/swagger/index.html
you will need to change the  PortNumber:
![alt text](swagger_home.PNG)

- ### Create Payment :
![alt text](post_payment.PNG)

- ### Retrieve Payment :
![alt text](get_payment.PNG)

## 2- Run the ReactJS CLient:
for this purpose you need to run the API and the ReactCLient application so you should setup multiples startups projects
![alt text](set_startup_projects.PNG)

### React Client
![alt text](react_client.PNG)

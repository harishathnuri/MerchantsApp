## Merchants Application

An application to create, view, update and delete merchants.

**Frontend**

The frontend is built using React and use reactstrap for styles.

**Backend**

The backend is built using asp.net core, entityframework core and mssql server on docker

**Continious delivery**

Artefacts are delivered using docker-compose for application and database

**Testing**

Application is tested using postman scripts and the same is available in Tests folder

**Endpoint details**

1. `GET /api/merchants` - gets all merchants.
2. `GET /api/merchants/{merchantId}` - gets the merchant that matches the specified Id - Id is a GUID.
3. `POST /api/merchants` - creates a new merchant.
4. `PUT /api/merchants/{merchantId}` - updates a merchant.
5. `DELETE /api/merchants/{id}` - deletes a merchant.
6. `GET /api/merchants/countries/all` - get all the countries.
7. `GET /api/merchants/currencies/all` - Gets all the currencies.
8. `GET /api/merchants/statues/all` - Gets all the statues.

All models are specified in the `/Models` folder, but should conform to:

**Merchant:**

```
{
"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
"name": "string",
"status": 1,
"countryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
"websiteUrl": "string",
"currencyId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
"discountPercentage": 10
}
```

**Merchants:**

```
{
  "Items": [
    {
      // merchant
    },
    {
      // merchant
    }
  ]
}
```

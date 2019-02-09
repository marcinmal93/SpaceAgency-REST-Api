# SpaceAgency REST Api


## Http Authentication ## 

Product Content Administrator account:
 
Username: admin@spaceagency.com
Password: 123$rewQ


## Missions ##

GET /api/missions
GET /api/missions/id

POST /api/missions (body: json)
example body:
{
    "name": "Mision1",
    "startDate": "2019-02-04T00:00:00",
    "finishDate": "2019-02-10T00:00:00",
    "missionTypeId": 1
}

PUT /api/missions/id (body: json)
example body:
{
    "name": "Mision111",
    "startDate": "2019-02-04T00:00:00",
    "finishDate": "2019-02-10T00:00:00",
    "missionTypeId": 2
}

DELETE /api/missions/id


## Products ##

GET /api/products
GET /api/products/id
GET /api/products?name=<mision name>&dateFrom=<acquisition date>&dateTo<date> (date format: yyyy-mm-dd)

POST /api/products (body: json)
example body:
{
    "acquisitionDate": "2019-02-04T00:00:00",
    "price": 1000.00,    
    "missionId": 1
}

PUT /api/products (body: json)
example body:
{
    "acquisitionDate": "2019-02-04T00:00:00",
    "price": 1250.00,    
    "missionId": 2
}

DELETE /api/products/id

# SalesDataAPI

In the project directory, run:

docker-compose build

docker-compose run

# API Documentation
Where the field {YY-MM-DD} represent a date like 2018-12-25

- Post sales data : POST /api/article/
```json
http code 201
{
  "id": 10,
  "articleNumber": "articleNumber6",
  "salesPrice": 32.2
}
```

- Number of sold articles per day : GET /api/articles/{YY-MM-DD}

Return the number of articles sold on that day {YY-MM-DD}
    
```json
http code 200
{
  "Number of sold articles": 3,
  "Date": "1/1/2021" 
}
```

- Total revenue per day : GET /api/articles/revenues/{YY-MM-DD}

Return the sum of prices of the articles sold on {YY-MM-DD}
```json
http code 200
{
   "Total Revenue": 46.5,
  "Date": "1/1/2021"
}
```

- Statistics : Revenue grouped by articles : GET /api/articles/revenues/{YY-MM-DD}/{YY-MM-DD}

Returns an aggregate count and total of articles sold from {firstDate } / {secondDate}

Assuming : multiple sold item can have the same article number.
```json
http code 200
[
  {
    "articleNumber": "articleNumber1",
    "count": 2,
    "total": 20.5
  },
  {
    "articleNumber": "articleNumber2",
    "count": 2,
    "total": 30.5
  },
  {
    "articleNumber": "articleNumber3",
    "count": 5,
    "total": 10.5
  },
  {
    "articleNumber": "articleNumber4",
    "count": 1,
    "total": 50.5
  }
]


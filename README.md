
## Auth
#### RegisterUser 

```http
  Post /api/Auth/UserRegister
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `FirstName,LastName,Email,Passowrd ` | `string` | **Required** All Variables Are Required |

When User Hit this url  then the user Role is User

#### RegisterUser
```http
  Post /api/Auth/AdminRegister
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `FirstName,LastName, Email ,Passowrd`    | `string` | **Required**. All Variables Are Required |

When User Hit this url  then the user Role is Admin


#### Login
```http
  Post /api/Auth/Login
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Email ,Passowrd`    | `string` | **Required**. All Variables Are Required |

When User Hit this url  then the Response is send  by api is jwt token.


## Todo
###  Only Authorize Users can  Access Todo controller.and Only Admin Role User can Access all  the Routes wheres User Role can Only Access GetAll Todo Route

 
#### Add Todo Item  

```http
  Post /api/Todo
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `tittle,Description,token` | `string,string ,jwttoken` | **Required** All Variables Are Required |

Here token is send by Authorization header
#### Get All Todo Item
```http
  Get /api/Todo
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `token`    | `jwttoken` | **Required**. All Variables Are Required |

Here token is send by Authorization header


#### Update
```http
  Put /api/Todo/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `tittle,Description,token,id`    | `string,string ,jwttoken,int` | **Required**. All Variables Are Required |

##### Here Tittle and Description is send by body
##### token is send in Authorization header

#### Delete
```http
  Delete /api/Todo/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `token,id`    | `jwttoken,int` | **Required**. All Variables Are Required |

##### token is send in Authorization header



#### Get Todo By Id
```http
  Get /api/Todo/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `token,id`    | `jwttoken,int` | **Required**. All Variables Are Required |

##### token is send in Authorization header

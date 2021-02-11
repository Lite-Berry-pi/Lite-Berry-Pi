# LiteBerryPi

## Project Lite Berry Pi App
---
### We are deployed on Azure!
[Deployed Server](https://liteberrypiserver.azurewebsites.net/)<br>
[Server GitHub](https://github.com/Lite-Berry-pi/lite-berry-pi-server)<br>

[App / SwaggerUI](https://lite-berry-pi20210208174150.azurewebsites.net/index.html)<br>

---
## Table of Contents
+ [Tools Used](#tools-used)
+ [Getting Started](#getting-started)
+ [Usage](#usage)
+ [Data Flow](#data-flow)
+ [Data Models](#data-models)
+ [Model Props and Requirements](#model-properties-and-requirements)
+ [The RaspBerryPi Schematics](#the-raspberrypi-schematics)
+ [Change Log](#change-log)
+ [Authors](#authors)
+ [Attributions](#attributions)

---
## Web Application
***[Explain your app, should be at least a paragraph. What does it do? Why should I use? Sell your product!]***

lite berry pi does this pitch here

---

## Tools Used
Microsoft Visual Studio Community 2019 *(Version 16.8.3)*

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- Azure
- Identity
- SignalR
- RaspBerryPi

---


## Getting Started

How to use the thing

---

## Usage
***[Provide some images of your app with brief description as title]***



### Creating a LiteBerry Design
![Post Creation](assets/post.png)
![Post Response](assets/post_res.png)

### Sending a LiteBerry Design
![Enriching Post](assets/get.png)

### The RaspBerryPi
![Details of Post](assets/liteberry.png)

---
## Data Flow
![Domain](assets/Lite-Berry_domain.png)

### ERD

![Data Flow Diagram](/assets/Lite-Berry_ERD.png)
+ User  1:many UserDesign
+ User  1:1  ActivityLog
+ UserDesign 1: many Design

---
## Data Models

### User Schema
*route:* `/api/user`
```
[
  {
    "id": 0,
    "name": "string",
    "activityLogs": [
      {
        "id": 0,
        "loginTime": "2021-02-10T23:22:44.804Z",
        "sendTime": "2021-02-10T23:22:44.804Z",
        "designs": [...],
      }
    "userDesigns": [
      {
        "id": 0,
        "title": "string",
        "designCoords": "string"
      }
    ]
  }
]
```
### Design Schema
*route:* `/api/design`
```
[
  {
    "id": 0,
    "title": "string",
    "timeStamp": "2021-02-10T23:48:54.091Z",
    "designCoords": "string",
    "userDesign": {...}
  }
]
```
### ActivityLog Schema
*route:* `/api/activitylog`
```
[
  {
    "id": 0,
    "loginTime": "2021-02-10T23:51:25.048Z",
    "sendTime": "2021-02-10T23:51:25.048Z",
    "designs": [...],
    "user": {...}
  }
]      
```
---
## Model Properties and Requirements

<table>
  <tr>
  <td>

  ### **User**
| Parameter | Type | Required |
| --- | --- | --- |
| Id  | `int` | YES |
| Name | `string` | YES |
| --- | --- | --- |
| ActivityLog | `List<ActivityLog>` | NAV |
| UserDesigns | `List<DesignDtos>` | NAV |

  </td>
  <td>
  
  ### **Design**
| Parameter | Type | Required |
| --- | --- | --- |
| Id  | `int` | YES |
| Title | `string` | YES |
| TimeStamp | `DateTime` | NO |
| DesignCoords | `string` | YES |
| --- | --- | --- |
| UserDesign | `UserDesign` | NAV |

  </td>
  </tr>
    <tr>
  <td>
  
  ### **ActivityLog** 
| Parameter | Type | Required |
| --- | --- | --- |
| Id  | `int` | YES |
| LoginTime | `DateTime` | NO |
| SendTime | `DateTime` | NO |
| --- | --- | --- |
| Designs | `List<Designs>` | NAV |
| User | `User` | NAV |

  </td>
  <td>
  
### **UserDesign**
*pure join table* 
| Parameter | Type | Required |
| --- | --- | --- |
| UserId  | `int` | --- |
| DesignId | `int` | --- |
| --- | --- | --- |
| Designs | `Design` | NAV |
| User | `User` | NAV |
  
  </td>
  </tr>
    <tr>
  <td>
  
  ### **ApplicationUserDto** 
| Parameter | Type | Required |
| --- | --- | --- |
| Id  | `int` | YES |
| Username | `string` | YES |
| Token | `string` | --- |
  
  </td>
  <td>
  
  ### **LoginData**
| Parameter | Type | Required |
| --- | --- | --- |
| Id  | `int` | YES |
| Username | `string` | YES |
| Token | `string` | --- |

  </td>
  </tr>
    <tr>
  <td>
  
  ### **RegisterUser**
| Parameter | Type | Required |
| --- | --- | --- |
| Username | `string` | YES |
| Password | `string` | YES |

  </td>
  <td>
  
### **UserDto**
| Parameter | Type | Required |
| --- | --- | --- |
| Id  | `int` | YES |
| Name | `string` | YES |
| --- | --- | --- |
| ActivityLog | `List<ActivityLog>` | NAV |
| UserDesigns | `List<DesignDtos>` | NAV |
  
  </td>
  <tr>
  <td>
  
  ### **DesignDto**
| Parameter | Type | Required |
| --- | --- | --- |
| Id  | `int` | YES |
| Title | `string` | YES |
| DesignCoords | `string` | YES |
| --- | --- | --- |
| UserDesign | `UserDesign` | NAV |
  
  </td>
  <td></td>
  </tr>
</table>
---

## The RaspBerryPi Schematics
![Schematics](assets/RaspLEDWB.png)

---

## Change Log
+ *02/08/2021* - 
  + Wired up the ASP.NET Core MVC Api App.
  + Built the model classes for the database
  + 

---

## Authors
+ [JP Jones](https://github.com/4a50)
+ [Kjell Overholt](https://github.com/Overholtk)
+ [Krystian Francuz-Harris](https://github.com/KrystianFH)
+ [Michael Falk](https://github.com/MikeyFalk)
+ [Scott Falbo](https://github.com/scottfalbo)

## Attributions
+ Bade Habib
+ John Cokos
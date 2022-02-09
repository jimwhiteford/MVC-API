RESTfull-API
========

This is a REST API example using ASP.NET,it interacts with a SQL Server Data Base. ther is no front end as it is a university project but can be tested on Postman/Insomnia. Below are some Instructions to do so if you want to test it.

Instructions:
- 
- Press F5 to run, you will see a welcome page. This indicates the REST API has been started in your IIS express
- Download Fiddler if you don't have already, this is an awesome tool (download it from http://www.telerik.com/fiddler)
- Open Fiddler Composer > Scratchpad and paste below http request contents
- Select any of the request and hit the 'Execute' button
- On the left hand side you will see the http traffic that you just made
- Select that traffic, go to 'Inspectors' tab. On the right hand side you will see two splitted windows. On the bottom one, select the JSON tab. Here we will see the response from the server

![](images/ERD.jpg)

I tried to explain above steps using this video, hope this will help you https://www.youtube.com/watch?v=83afZKbng6k

####GET

```sh
GET http://localhost:55570/api/employee HTTP/1.1
Host: localhost:55570
Connection: keep-alive
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36
Accept-Encoding: gzip,deflate,sdch
Accept-Language: en-GB,en-US;q=0.8,en;q=0.6
```

####POST

```sh
POST http://localhost:55570/api/employee HTTP/1.1
Host: localhost:55570
Connection: keep-alive
Content-Length: 42
Accept: */*
Origin: http://localhost:55570
X-Requested-With: XMLHttpRequest
User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36
Content-Type: application/json; charset=UTF-8
Accept-Encoding: gzip,deflate
Accept-Language: en-GB,en-US;q=0.8,en;q=0.6

{"Id":4,"Name":"Rishi Karmakar","Role":"Program Manager"}
```

####DELETE

```sh
DELETE http://localhost:55570/api/employee/1 HTTP/1.1
Host: localhost:55570
Connection: keep-alive
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36
Accept-Encoding: gzip,deflate,sdch
Accept-Language: en-GB,en-US;q=0.8,en;q=0.6
Content-Length: 0
```

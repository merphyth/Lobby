using WebApplication1;
using System.Text.RegularExpressions;
using System.Linq;
using System;
List<Car> cars = new List<Car>()
{
    new Car() {Id = 1,MaxSpeed = 120F,Model = "Model1",Description = "good car"},
    new Car() {Id = 2,MaxSpeed = 130F,Model = "Model2",Description = "bad car"},
    new Car() {Id = 3,MaxSpeed = 180F,Model = "Model3",Description = "good car"}
};
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run(async (context) => 
{
    var request = context.Request;
    var response = context.Response;
    var path = context.Request.Path;
    string expressionForNumber = "^/api/cars/([0-9]+)$";
    if (path == "/api/cars" && request.Method == "GET")
    {
        await response.WriteAsJsonAsync(cars);
    }
    else if (Regex.IsMatch(path, expressionForNumber) && request.Method == "GET")
    {
        int intvar = int.Parse(path.Value?.Split("/")[3]);
        try
        {
            Car mycar = cars.FirstOrDefault((i) => i.Id == intvar);
            if (mycar == null)
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new
                {
                    message = "no such car"
                });
            }
            else
            {
                await response.WriteAsJsonAsync(mycar);
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            await response.WriteAsJsonAsync(new
            {
                message = "server Error"
            });
        }

    }
    else if (path == "/api/cars" && request.Method == "POST")//вставить значение
    {
        try
        {
            Car tempcar = await request.ReadFromJsonAsync<Car>();
            if (tempcar != null)
            {
                cars.Add(tempcar);
                await response.WriteAsJsonAsync(tempcar);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new
                {
                    message = "car == null"
                });
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            await response.WriteAsJsonAsync(new
            {
                message = "server Error"
            });
        }
    }
    else if (path == "/api/cars" && request.Method == "PUT")//заменить
    {
        try
        {
            Car tempcar = await request.ReadFromJsonAsync<Car>();
            if (tempcar != null)
            {
                Car existingCar = cars.FirstOrDefault(c => c.Id == tempcar.Id);
                if (existingCar != null)
                {
                    existingCar.MaxSpeed = tempcar.MaxSpeed;
                    existingCar.Model = tempcar.Model;
                    existingCar.Description = tempcar.Description;

                    await response.WriteAsJsonAsync(existingCar);
                }
                else
                {
                    response.StatusCode = 404;
                    await response.WriteAsJsonAsync(new
                    {
                        message = "Car not found"
                    });
                }
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new
                {
                    message = "Car data missing"
                });
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            await response.WriteAsJsonAsync(new
            {
                message = "Server Error"
            });
        }
    }
    else if (Regex.IsMatch(path, expressionForNumber) && request.Method == "DELETE") 
    {
        int intvar1 = int.Parse(path.Value?.Split("/")[3]);
        try
        {
            Car mycar = cars.FirstOrDefault((i) => i.Id == intvar1);
            if (mycar == null)
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new
                {
                    message = $"there is no car with id{intvar1}"
                });
            }
            else
            {
                cars.Remove(mycar);
                await response.WriteAsJsonAsync(mycar);
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            await response.WriteAsJsonAsync(new
            {
                message = "server Error"
            });
        }
    }
    else if(path == "/api/cars/table" && request.Method == "GET")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("htmlpage.html");
    }
    else if (path == "/api/cars/add")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("add.html");
    }
});
app.Run();

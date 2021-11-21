using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ValueObjectAsField.Domain.Models;
using ValueObjectAsField.Persistence.DbContexts;

namespace ValueObjectAsField
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ShopDbContext();
            Console.WriteLine("--------------------------------Insert an order----------------------------------------------------");
            var orderForInsert = Order.Create();
            orderForInsert.SetName("Sajad", "Vahmi");
            orderForInsert.SetAddress("Tehran", "Komeil", 24, "1236547890");
            var orderLines = new List<OrderLine>()
            {
                OrderLine.CreateWith(1,2,2000),
                OrderLine.CreateWith(2,2,3000),
                OrderLine.CreateWith(2,2,4000),

            };
            orderForInsert.AssignLines(orderLines);
            dbContext.Add(orderForInsert);
            dbContext.SaveChanges();
            Console.WriteLine($"Inserted Id: {orderForInsert.Id.Value}");
            Console.WriteLine($"Inserted Name.Firstname: {orderForInsert.Name.Firstname}");
            Console.WriteLine($"Inserted Name.Lastname: {orderForInsert.Name.Lastname}");
            Console.WriteLine($"Inserted Address.City: {orderForInsert.Address.City}");
            Console.WriteLine($"Inserted Address.Street: {orderForInsert.Address.Street}");
            Console.WriteLine($"Inserted Address.Unit: {orderForInsert.Address.Unit}");
            Console.WriteLine($"Inserted Address.ZipCode: {orderForInsert.Address.ZipCode}");
            int line = 1;
            foreach (var item in orderForInsert.OrderLines)
                Console.WriteLine($"Inserted OrderLine {line++}: ProductId:{item.ProductId} Quantity:{item.Quantity} Price:{item.Price}");

            Console.WriteLine("--------------------------------Fetch order from database---------------------------------------");
            var orderFromDatabaseQuery = dbContext.Orders.Where(s => s.Id == orderForInsert.Id);
            Console.WriteLine($"SQL Query For Fetch is: {orderFromDatabaseQuery.ToQueryString()}");
            var orderFromDatabase = orderFromDatabaseQuery.AsNoTracking().FirstOrDefault();
            Console.WriteLine($"Fetched Id: {orderFromDatabase.Id.Value}");
            Console.WriteLine($"Fetched Name.Firstname: {orderFromDatabase.Name.Firstname}");
            Console.WriteLine($"Fetched Name.Lastname: {orderFromDatabase.Name.Lastname}");
            Console.WriteLine($"Fetched Address.City: {orderFromDatabase.Address.City}");
            Console.WriteLine($"Fetched Address.Street: {orderFromDatabase.Address.Street}");
            Console.WriteLine($"Fetched Address.Unit: {orderFromDatabase.Address.Unit}");
            Console.WriteLine($"Fetched Address.ZipCode: {orderFromDatabase.Address.ZipCode}");
            line = 1;
            foreach (var item in orderFromDatabase.OrderLines)
                Console.WriteLine($"Inserted OrderLine {line++}: ProductId:{item.ProductId} Quantity:{item.Quantity} Price:{item.Price}");

            //Console.WriteLine("--------------------------------Fetch order from database with a value object--------------------");
            //var orderFromDatabaseWithValueObjectQuery = dbContext.Orders.Where(s => s.Address == orderForInsert.Address);
            //Console.WriteLine($"SQL Query For Fetch is: {orderFromDatabaseWithValueObjectQuery.ToQueryString()}");
            //var orderFromDatabaseWithValueObject = orderFromDatabaseWithValueObjectQuery.AsNoTracking().FirstOrDefault();
            //Console.WriteLine($"Fetched Id: {orderFromDatabaseWithValueObject.Id.Value}");
            //Console.WriteLine($"Fetched Name.Firstname: {orderFromDatabaseWithValueObject.Name.Firstname}");
            //Console.WriteLine($"Fetched Name.Lastname: {orderFromDatabaseWithValueObject.Name.Lastname}");
            //Console.WriteLine($"Fetched Address.City: {orderFromDatabaseWithValueObject.Address.City}");
            //Console.WriteLine($"Fetched Address.Street: {orderFromDatabaseWithValueObject.Address.Street}");
            //Console.WriteLine($"Fetched Address.Unit: {orderFromDatabaseWithValueObject.Address.Unit}");
            //Console.WriteLine($"Fetched Address.ZipCode: {orderFromDatabaseWithValueObject.Address.ZipCode}");
            //line = 1;
            //foreach (var item in orderFromDatabaseWithValueObject.OrderLines)
            //    Console.WriteLine($"Inserted OrderLine {line++}: ProductId:{item.ProductId} Quantity:{item.Quantity} Price:{item.Price}");

            Console.WriteLine("--------------------------------Fetch order from database with a value of value object--------------------");
            var orderFromDatabaseWithValueOfValueObjectQuery = dbContext.Orders.Where(s => s.Address.Unit == orderForInsert.Address.Unit);
            Console.WriteLine($"SQL Query For Fetch is: {orderFromDatabaseWithValueOfValueObjectQuery.ToQueryString()}");
            var orderFromDatabaseWithValueOfValueObject = orderFromDatabaseWithValueOfValueObjectQuery.AsNoTracking().FirstOrDefault();
            Console.WriteLine($"Fetched Id: {orderFromDatabaseWithValueOfValueObject.Id.Value}");
            Console.WriteLine($"Fetched Name.Firstname: {orderFromDatabaseWithValueOfValueObject.Name.Firstname}");
            Console.WriteLine($"Fetched Name.Lastname: {orderFromDatabaseWithValueOfValueObject.Name.Lastname}");
            Console.WriteLine($"Fetched Address.City: {orderFromDatabaseWithValueOfValueObject.Address.City}");
            Console.WriteLine($"Fetched Address.Street: {orderFromDatabaseWithValueOfValueObject.Address.Street}");
            Console.WriteLine($"Fetched Address.Unit: {orderFromDatabaseWithValueOfValueObject.Address.Unit}");
            Console.WriteLine($"Fetched Address.ZipCode: {orderFromDatabaseWithValueOfValueObject.Address.ZipCode}");
            line = 1;
            foreach (var item in orderFromDatabaseWithValueOfValueObject.OrderLines)
                Console.WriteLine($"Fetched OrderLine {line++}: ProductId:{item.ProductId} Quantity:{item.Quantity} Price:{item.Price}");

            Console.WriteLine("--------------------------------Fetch order from database with compare a value of value object--------------------");
            var orderFromDatabaseWithCompareValueOfValueObjectQuery = dbContext.Orders.Where(s => s.Address.Unit > 10);
            Console.WriteLine($"SQL Query For Fetch is: {orderFromDatabaseWithCompareValueOfValueObjectQuery.ToQueryString()}");
            var orderFromDatabaseWithCompareValueOfValueObject = orderFromDatabaseWithCompareValueOfValueObjectQuery.AsNoTracking().FirstOrDefault();
            Console.WriteLine($"Fetched Id: {orderFromDatabaseWithCompareValueOfValueObject.Id.Value}");
            Console.WriteLine($"Fetched Name.Firstname: {orderFromDatabaseWithCompareValueOfValueObject.Name.Firstname}");
            Console.WriteLine($"Fetched Name.Lastname: {orderFromDatabaseWithCompareValueOfValueObject.Name.Lastname}");
            Console.WriteLine($"Fetched Address.City: {orderFromDatabaseWithCompareValueOfValueObject.Address.City}");
            Console.WriteLine($"Fetched Address.Street: {orderFromDatabaseWithCompareValueOfValueObject.Address.Street}");
            Console.WriteLine($"Fetched Address.Unit: {orderFromDatabaseWithCompareValueOfValueObject.Address.Unit}");
            Console.WriteLine($"Fetched Address.ZipCode: {orderFromDatabaseWithCompareValueOfValueObject.Address.ZipCode}");
            line = 1;
            foreach (var item in orderFromDatabaseWithCompareValueOfValueObject.OrderLines)
                Console.WriteLine($"Fetched OrderLine {line++}: ProductId:{item.ProductId} Quantity:{item.Quantity} Price:{item.Price}");


            Console.WriteLine("--------------------------------Fetch order for assign lines--------------------");
            var orderLinesForAssign = new List<OrderLine>()
            {
                OrderLine.CreateWith(5,2,6000),
                OrderLine.CreateWith(6,2,1000),
                OrderLine.CreateWith(7,2,8000),

            };

            var orderFromDatabaseForAssignLines = dbContext.Orders.Where(s => s.Id == orderForInsert.Id).FirstOrDefault();
            orderFromDatabaseForAssignLines.AssignLines(orderLinesForAssign);
            dbContext.SaveChanges();

            foreach (var item in orderFromDatabaseForAssignLines.OrderLines)
                Console.WriteLine($"Inserted OrderLine {line++}: ProductId:{item.ProductId} Quantity:{item.Quantity} Price:{item.Price}");

            var orderLinesForUpdate = new List<OrderLine>()
            {
                OrderLine.CreateWith(10,2,18000),
                OrderLine.CreateWith(6,2,1000),
                OrderLine.CreateWith(12,2,45000),

            };

            orderFromDatabaseForAssignLines.UpdateLines(orderLinesForUpdate);
            dbContext.SaveChanges();

            foreach (var item in orderFromDatabaseForAssignLines.OrderLines)
                Console.WriteLine($"Fetched OrderLine {line++}: ProductId:{item.ProductId} Quantity:{item.Quantity} Price:{item.Price}");

        }
    }
}

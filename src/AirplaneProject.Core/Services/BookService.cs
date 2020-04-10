using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AirplaneProject.Core.Services
{
	public class BookService
	{
		private readonly IMongoCollection<Book> _books;

		public BookService(IBookstoreDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_books = database.GetCollection<Book>(settings.BooksCollectionName);
		}

		public List<Book> Get() =>
			_books.Find(book => true).ToList();

		public Book Get(string id) =>
			_books.Find<Book>(book => book.Id == id).FirstOrDefault();

		public Book Create(Book book)
		{
			_books.InsertOne(book);
			return book;
		}

		public void Update(string id, Book bookIn) =>
			_books.ReplaceOne(book => book.Id == id, bookIn);

		public void Remove(Book bookIn) =>
			_books.DeleteOne(book => book.Id == bookIn.Id);

		public void Remove(string id) =>
			_books.DeleteOne(book => book.Id == id);
	}
}

using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class LibraryAssetService : ILibraryAsset

    {
        private LibraryContext _context;
        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(ILibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }
        public LibraryAsset GetById(int id)
        {
            return 
                GetAll().FirstOrDefault(asset => asset.ID == id);
             //_context.LibraryAssets
            //    .Include(asset => asset.Status)
            //    .Include(asset => asset.Location)
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
            //return _context.LibraryAssets.FirstOrDefault(asset => asset.ID == id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            /*var isBook = _context.LibraryAssets.OfType<Book>().Where(book => book.ID == id);
            return isBook.FirstOrDefault(book => book.ID == id).DeweyIndex;*/
            if (_context.Books.Any(book => book.ID == id))
            {
                return _context.Books.FirstOrDefault(asset => asset.ID == id).DeweyIndex;
            }
            else return "Book deweyIndex does not founs";
        }

        public string GetISBN(int id)
        {
            if (_context.LibraryAssets.Any(book => book.ID == id))
            {
                return _context.Books.FirstOrDefault(book => book.ID == id).ISBN;
            }
            else
                return "ISBN Not found";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(book => book.ID == id).Title;
        }

        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>().Where(b => b.ID == id);
            return book.Any() ?
                "Book" : "Video";
        }
        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>().Where(book => book.ID == id).Any();
            var isVideo = _context.LibraryAssets.OfType<Video>().Where(video => video.ID == id).Any();
            return isBook ?
                _context.Books.FirstOrDefault(book => book.ID == id).Author :
                _context.Videos.FirstOrDefault(video => video.ID == id).Director
                ?? $"Unknown {id}";
        }

        public void Add(LibraryAsset newAsset)
        {
            throw new NotImplementedException();
        }
    }
}

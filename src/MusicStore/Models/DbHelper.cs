﻿using System;
using MusicStore.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MusicStore
{
    public static class DbHelper
    {
        public static IQueryable<Album> GetAllAlbums(MusicStoreContext db)
        {
            var query = from album in db.Albums
                        join genre in db.Genres on album.GenreId equals genre.GenreId
                        join artist in db.Artists on album.ArtistId equals artist.ArtistId
                        select new Album()
                        {
                            ArtistId = album.ArtistId,
                            AlbumArtUrl = album.AlbumArtUrl,
                            AlbumId = album.AlbumId,
                            GenreId = album.GenreId,
                            Price = album.Price,
                            Title = album.Title,
                            Artist = new Artist()
                            {
                                ArtistId = album.ArtistId,
                                Name = artist.Name
                            },
                            Genre = new Genre()
                            {
                                GenreId = album.GenreId,
                                Name = genre.Name
                            }
                        };

            return query;
        }

        public static IQueryable<Album> GetAlbumDetails(MusicStoreContext db, int albumId)
        {
            var query = from album in db.Albums
                        join genre in db.Genres on album.GenreId equals genre.GenreId
                        join artist in db.Artists on album.ArtistId equals artist.ArtistId
                        where album.AlbumId == albumId
                        select new Album()
                        {
                            ArtistId = album.ArtistId,
                            AlbumArtUrl = album.AlbumArtUrl,
                            AlbumId = album.AlbumId,
                            GenreId = album.GenreId,
                            Price = album.Price,
                            Title = album.Title,
                            Artist = new Artist()
                            {
                                ArtistId = album.ArtistId,
                                Name = artist.Name
                            },
                            Genre = new Genre()
                            {
                                GenreId = album.GenreId,
                                Name = genre.Name
                            }
                        };

            return query;
        }
    }
}
﻿using System;
using Newtonsoft.Json;

namespace LibraryService.WebAPI.SeedData
{
    public class UpdateBooksForm
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("authorName")]
        public string AuthorName { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("publishedDate")]
        public DateTime PublishedDate { get; set; }
    }
}

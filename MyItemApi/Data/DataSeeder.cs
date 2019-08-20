using Microsoft.AspNetCore.Hosting;
using MyItemApi.Data.Entities;
using MyNoteApi.Data;
using MyNoteApi.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Data
{
    public class DataSeeder
    {
        private readonly ItemContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public DataSeeder(ItemContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Owners.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/owners.json");
                var json = File.ReadAllText(filepath);
                var owners = JsonConvert.DeserializeObject<IEnumerable<Owner>>(json);
                _ctx.Owners.AddRange(owners);
                await _ctx.SaveChangesAsync();
            }

            if (!_ctx.Users.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/User.json");
                var json = File.ReadAllText(filepath);
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                _ctx.Users.AddRange(users);
                await _ctx.SaveChangesAsync();
            }

            if (!_ctx.AttributeNames.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/AttributeName.json");
                var json = File.ReadAllText(filepath);
                var attributeNames = JsonConvert.DeserializeObject<IEnumerable<AttributeName>>(json);
                _ctx.AttributeNames.AddRange(attributeNames);
                await _ctx.SaveChangesAsync();
            }

            if (!_ctx.AttributeValues.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/AttributeValue.json");
                var json = File.ReadAllText(filepath);
                var attributeValues = JsonConvert.DeserializeObject<IEnumerable<AttributeValue>>(json);
                _ctx.AttributeValues.AddRange(attributeValues);
                await _ctx.SaveChangesAsync();
            }

        }
    }
}

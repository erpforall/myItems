using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyItemApi.Controllers;
using MyItemApi.Model;
using MyItemApi.Respositories;
using MyNoteApi.Data;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        AttributeController _attributeController;
        IAttributeRepository _attributeRepository;
        ItemContext _itemContext;
        int categoryId;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            _itemContext = new ItemContext(options);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMappingProfile());
            });
            IMapper _mapper = new Mapper(config);
            _attributeRepository = new AttributeRepository(_itemContext, _mapper);
            _attributeController = new AttributeController(_attributeRepository);
        }

        [Test]
        public async Task Test1()
        {
            string categoryName = "AttrCate1";
            ActionResult<AttributeCategoryView> result = await _attributeController.PostCategory(new AttributeCategoryView { Name = categoryName });

            var rrr = result.Result;
            categoryId = result.Value.AttributeCategoryId;
            Assert.AreEqual(result.Value.Name, categoryName);
        }

        [Test]
        public async Task Test2()
        {
            string categoryName = "AttrCate1";
            ActionResult<AttributeCategoryView> result = await _attributeController.GetCategory(1);

            var rrr = result.Value;
            categoryId = result.Value.AttributeCategoryId;
            Assert.AreEqual(result.Value.Name, categoryName);
        }

    }
}
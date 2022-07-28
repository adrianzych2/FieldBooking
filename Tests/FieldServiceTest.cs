using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldBooking.Data.Models;
using FieldBooking.Domain.Models;
using FieldBooking.Domain.Models.Enums;
using FieldBooking.Domain.Repository;
using FieldBooking.Services;
using FieldBooking.Services.BusinessValidation;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Xunit;

namespace FieldBooking.Tests
{
    
    public class FieldServiceTest
    {
        private readonly FieldService _fieldService;
        private readonly Mock<IFieldRepository> _fieldRepositoryMock;
        private readonly Mock<IFieldValidationService> _fieldValidationServiceMock;
        private List<FieldDto> fields;
        private FieldDto _fieldDto;


        public FieldServiceTest()
        {
            _fieldRepositoryMock = new Mock<IFieldRepository>();
            _fieldValidationServiceMock = new Mock<IFieldValidationService>();
            _fieldService = new FieldService(_fieldRepositoryMock.Object, _fieldValidationServiceMock.Object);
            _fieldDto = new FieldDto(){Id = 1};
            fields = new List<FieldDto>();
            fields.Add(new FieldDto()
            {
                Id = 1,
                Address = new AddressDto() {Id = 1, City = "London", Street = "Example", StreetNumber = 6},
                AddressId = 1,
                Calendar = new CalendarDto() {Id = 1},
                CalendarId = 1,
                FieldType = FieldType.Basketball,
                Name = "WestField",
                OneBookingTime = DateTime.Parse("1:00"),
                Price = 100
            });
            fields.Add(new FieldDto()
            {
                Id = 1,
                Address = new AddressDto() {Id = 2, City = "London", Street = "Example", StreetNumber = 5},
                AddressId = 2,
                Calendar = new CalendarDto() {Id = 2},
                CalendarId = 2,
                FieldType = FieldType.Basketball,
                Name = "EastField",
                OneBookingTime = DateTime.Parse("1:00"),
                Price = 200
            });
        }

        [Fact]

        public async void Create_WhenFieldsExists_CreateAsync()
        {
            //Arange
            _fieldDto.Name = fields[1].Name;
            _fieldRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(fields);
            _fieldValidationServiceMock.Setup(x => x.ValidateNewField(fields, _fieldDto)).Throws(new ArgumentException("This name already exists!"));
            Func<Task> action = async () => await _fieldService.CreateAsync(_fieldDto);
            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            //Assert
            Assert.Equal("This name already exists!", ex.Message);
        }

        [Fact]
        public async void Create_WhenFieldsDoesNotExists_CreateAsync()
        {
            //Arange
            /*_fieldDto.Id = 5;
            _fieldDto.Name = "NewField";
            _fieldDto.Address = new AddressDto();
            _fieldDto.Address.Id = 1;
            _fieldDto.Address.Street = "Example";
            _fieldDto.Address.StreetNumber = 1;
            _fieldDto.Address.City = "London";*/
            _fieldRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(fields);
            _fieldRepositoryMock.Setup(x => x.CreateAsync(_fieldDto)).ReturnsAsync(_fieldDto);
            _fieldValidationServiceMock.Setup(x => x.ValidateNewField(fields, _fieldDto));

            //Act

            //Assert
            Assert.Equal(_fieldDto, _fieldService.CreateAsync(_fieldDto).Result);
        }

        [Fact]
        public async void Get_WhenFieldExists_GetAsync()
        {
            //Arange
            _fieldDto = fields[1];
            _fieldRepositoryMock.Setup(x => x.GetAsync(_fieldDto.Id)).ReturnsAsync(_fieldDto);

            //Assert
            Assert.Equal(_fieldDto, _fieldService.GetAsync(_fieldDto.Id).Result);
        }

        [Fact]
        public async void Get_WhenFieldDoesNotExists_GetAsync()
        {
            //Arange
            _fieldRepositoryMock.Setup(x => x.GetAsync(_fieldDto.Id)).ReturnsAsync((FieldDto)null);
            Func<Task> action = async () => await _fieldService.GetAsync(1);

            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);

            //Assert
            Assert.Equal($"Can't find field with specified id: 1", ex.Message);
        }

        [Fact]
        public async void GetAll_WhenDatabaseIsNotEmpty_GetAllAsync()
        {
            //Arange
            _fieldRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(fields);

            //Act
        
            //Assert
            Assert.Equal(fields, _fieldService.GetAllAsync().Result);
        }

        [Fact]
        public async void Remove_WhenFieldsIsInDatabase_RemoveAsync()
        {
            //Arrange
            _fieldDto = fields[0];
            _fieldRepositoryMock.Setup(x => x.RemoveAsync(_fieldDto.Id)).ReturnsAsync(_fieldDto);

            //Assert
            Assert.Equal(_fieldDto, _fieldService.RemoveAsync(1).Result);
        }

        [Fact]
        public async void Update_WhenFieldExists_UpdateAsync()
        {
            //Arrange
            _fieldDto = fields[0];
            _fieldRepositoryMock.Setup(x => x.UpdateAsync(_fieldDto)).ReturnsAsync(_fieldDto);

            //Assert
            Assert.Equal(_fieldDto, _fieldService.UpdateAsync(_fieldDto).Result);
        }


    }
}

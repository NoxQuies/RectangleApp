using Microsoft.AspNetCore.Mvc;
using RectangleDrawer.Controllers;
using RectangleDrawer.Models;
using Xunit;

namespace RectangleApp.Tests
{
    public class RectangleControllerTests
    {
        [Fact]
        public void Create_Get_ReturnsViewResult()
        {
            // Arrange
            var controller = new RectangleController();

            // Act
            var result = controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Expecting the default view to be returned
        }

        [Fact]
        public void Create_Post_ReturnsViewResult_WhenModelIsValid()
        {
            // Arrange
            var controller = new RectangleController();
            var model = new RectangleModel
            {
                Width = 100,
                Height = 200,
                FillColor = "red"
            };

            // Act
            var result = controller.Create(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Draw", viewResult.ViewName); // Expecting to render the Draw view
            Assert.IsType<RectangleModel>(viewResult.Model);
        }

        [Fact]
        public void Create_Post_ReturnsSameView_WhenModelIsInvalid()
        {
            // Arrange
            var controller = new RectangleController();
            var model = new RectangleModel
            {
                Width = 0, // Invalid width (out of range)
                Height = 200,
                FillColor = "red"
            };
            controller.ModelState.AddModelError("Width", "Width is out of range");

            // Act
            var result = controller.Create(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Expecting the default view to be returned
            Assert.IsType<RectangleModel>(viewResult.Model);
            Assert.False(viewResult.ViewData.ModelState.IsValid); // Model state is invalid
        }
    }
}

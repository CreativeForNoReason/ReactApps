using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReactApp.Controllers;
using ReactApp.Data;
using ReactApp.Data.HttpRequests;
using ReactApp.Data.Interfaces;
using ReactApp.Data.Repositories;
using ReactApp.Models;

namespace ReactAPPTests
{
    public class SolutionsRepositoryTests
    {
        [Theory]
        [AutoMoqData]
        public async Task PostCodeSolution_ReturnsNull_WhenStatusCodeNot200(
            CodeSolution solution,
            PostResponse response,
            [Frozen] Mock<IPostRequests> postRequests,
            SolutionRepository rep)
        {
            // arrange
            postRequests.Setup(x => x.GetResponseFromPostRequest(It.IsAny<string>())).ReturnsAsync(response);
            response.statusCode = 190;

            // act
            var result = await rep.PostCodeSolution(solution);

            // assert
            Assert.Null(result);
        }

        [Theory]
        [InlineAutoMoqData("Ok")]
        public async Task PostCodeSolution_ReturnsResultFromResponse_WhenStatusCodeIs200(
            string output,
            CodeSolution solution,
            PostResponse response,
            [Frozen] Mock<IPostRequests> postRequests,
            [Frozen] Mock<ILayeredDbContext> context,
            SolutionRepository rep)
        {
            // arrange
            postRequests.Setup(x => x.GetResponseFromPostRequest(It.IsAny<string>())).ReturnsAsync(response);
            context.Setup(x => x.SaveCodeSolutions(solution)).Verifiable();
            response.statusCode = 200;
            response.output = output;

            // act
            var result = await rep.PostCodeSolution(solution);

            // assert
            context.Verify(x => x.SaveCodeSolutions(solution), Times.Once());
            Assert.Equal(output, result.Result);
        }
    }
}
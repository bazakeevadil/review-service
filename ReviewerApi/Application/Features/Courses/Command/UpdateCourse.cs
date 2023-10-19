﻿using Application.Contract;
using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Command;

public record UpdateCouresCommand : IRequest<CourseDto?>
{
    public required long Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
}

internal class UpdateCourseHandler : IRequestHandler<UpdateCouresCommand, CourseDto?>
{
    private readonly ICourseRepo _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCourseHandler(ICourseRepo courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CourseDto?> Handle(UpdateCouresCommand command, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseById(command.Id);

        if (course is not null)
        {
            if (!string.IsNullOrEmpty(command.Name))
                course.Name = command.Name;
            if (!string.IsNullOrEmpty(command.Description))
                course.Description = command.Description;

            _courseRepository.Update(course);
            await _unitOfWork.CommitAsync();

            var response = new CourseDto
            {
                Id = course.Id,
                Name = command.Name,    
                Description = command.Description,
            };

            return response;
        }

        return default;
    }
}

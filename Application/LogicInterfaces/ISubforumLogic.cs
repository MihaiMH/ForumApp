using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface ISubforumLogic
{
    Task<Subforum> CreateAsync(SubforumDto subforumDto);
}
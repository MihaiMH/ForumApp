using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class SubforumLogic : ISubforumLogic
{
    private readonly ISubforumDao _subforumDao;

    public SubforumLogic(ISubforumDao subforumDao)
    {
        _subforumDao = subforumDao;
    }

    public async Task<Subforum> CreateAsync(SubforumDto subforumDto)
    {
        Subforum? exists = await _subforumDao.GetByTitleAsync(subforumDto.Title);
        if (exists != null)
        {
            throw new Exception("Subforum with this title already exists");
        }

        ValidateData(subforumDto);

        Subforum toCreate = new Subforum(subforumDto.Title, subforumDto.Owner);

        Subforum created = await _subforumDao.CreateAsync(toCreate);
        return created;
    }

    public static void ValidateData(SubforumDto subforumDto)
    {
        string title = subforumDto.Title;

        if (title.Length < 3)
        {
            throw new Exception("Title of the subforum must be at least 3 characters");
        }

        if (title.Length > 20)
        {
            throw new Exception("Title of the subforum must be shorter than 21 characters");
        }
    }
}
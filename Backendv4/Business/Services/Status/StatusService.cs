using Business.Dtos.Status;
using Business.Mappers;
using Business.Models;
using Business.Services.Status;
using Data.Repositories;

public class StatusService : IStatusService
{
    private readonly StatusRepository _repository;

    public StatusService(StatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StatusModel>> GetAllStatus()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(StatusMapper.ToModel)!;
    }

    public async Task<StatusModel?> AddAsync(AddStatusForm form)
    {
        var entity = StatusMapper.ToEntity(form);
        await _repository.AddAsync(entity);
        return StatusMapper.ToModel(entity);
    }

    public async Task<StatusModel?> UpdateAsync(UpdateStatusForm form)
    {
        var existing = await _repository.GetByIdAsync(form.Id);
        if (existing is null) return null;

        existing.StatusName = form.StatusName;

        await _repository.UpdateAsync(existing);
        return StatusMapper.ToModel(existing);
    }


}

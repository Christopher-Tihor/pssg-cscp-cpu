﻿namespace Manager.Contract;

public record ScheduleGQuery : IRequest<ScheduleGResult>
{
    public Guid? Id { get; set; }
    public Guid? ProgramId { get; set; }
    public Quarter? Quarter { get; set; }
}

public record ScheduleGResult(IEnumerable<ScheduleG> ScheduleGs);

public record ScheduleG : IDto {
    public Guid Id { get; set; }
    public StateCode StateCode { get; set; }
    // Maps to DL CpuReportingPeriod
    public Quarter? Quarter { get; set; }

    // References
    public Guid? ServiceProviderId { get; set; }
    public Guid? ProgramId { get; set; }
    public Guid? ContractId { get; set; }
}

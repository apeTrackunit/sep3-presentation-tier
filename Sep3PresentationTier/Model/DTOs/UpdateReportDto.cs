namespace Model.DTOs;

public class UpdateReportDto
{
    public string status { get; set; }

    public UpdateReportDto()
    {
    }

    public UpdateReportDto(string status)
    {
        this.status = status;
    }
}
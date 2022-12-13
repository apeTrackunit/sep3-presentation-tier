namespace Model.DTOs;

public class ValidateEventDto
{
    public byte[] validation { get; set; }

    public ValidateEventDto(byte[] validation)
    {
        this.validation = validation;
    }
}
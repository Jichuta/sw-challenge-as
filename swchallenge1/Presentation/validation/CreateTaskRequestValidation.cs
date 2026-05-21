using swchallenge1.Presentation.Dtos;

namespace swchallenge1.Presentation.validation;
public static class CreateTaskRequestValidation
{
    public static bool Validate(CreateTaskRequest request, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            errorMessage = "Title is required.";
            return false;
        }

        if (request.Title.Length > 100)
        {
            errorMessage = "Title cannot exceed 100 characters.";
            return false;
        }

        if (!string.IsNullOrWhiteSpace(request.Description) && request.Description.Length > 500)
        {
            errorMessage = "Description cannot exceed 500 characters.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}
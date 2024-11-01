using Microsoft.AspNetCore.Mvc.Rendering;

namespace Backend.Helpers;

public static class ImageHelper
{
    private static Lazy<List<string>> _imagesLazy = new(() =>
    {
        var wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var images = Directory.GetFiles(Path.Combine(wwwroot, "images"), "*.png", SearchOption.AllDirectories)
            .Select(x => x.Replace(wwwroot, "").Replace("\\", "/"))
            .ToList();

        return images;
    });

    public static List<string> Images => _imagesLazy.Value;

    public static List<SelectListItem> ImagesDropdown => Images.Select(path =>
    {
        var name = Path.GetFileNameWithoutExtension(path);

        return new SelectListItem(name, path);
    }).ToList();
}

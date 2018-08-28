
using Microsoft.AspNetCore.Mvc.ApplicationModels;

public static class PageConventionCollectionExtensions
{
    public static IPageRouteModelConvention AddFolderRouteParameter(
        this PageConventionCollection conventions,
        string folder,
        string routeParameter)
    {
        return conventions.AddFolderRouteModelConvention(folder, model =>
        {
            foreach (var s in model.Selectors)
            {
                var templateWithId = AttributeRouteModel
                    .CombineTemplates(s.AttributeRouteModel.Template, routeParameter);

                s.AttributeRouteModel.Template = templateWithId;
            }
        });
    }
}
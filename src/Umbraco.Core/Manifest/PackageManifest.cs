using System.Runtime.Serialization;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Extensions;

namespace Umbraco.Cms.Core.Manifest;

/// <summary>
/// Represents the content of a package manifest.
/// </summary>
[DataContract]
public class PackageManifest
{
    private string? _packageName;

    /// <summary>
    /// Gets or sets the package identifier.
    /// </summary>
    /// <value>
    /// The package identifier.
    /// </value>
    [DataMember(Name = "id")]
    public string? PackageId { get; set; }

    /// <summary>
    /// Gets or sets the name of the package. If not specified, uses the package identifier or directory name instead.
    /// </summary>
    /// <value>
    /// The name of the package.
    /// </value>
    [DataMember(Name = "name")]
    public string? PackageName
    {
        get
        {
            if (!_packageName.IsNullOrWhiteSpace())
            {
                return _packageName;
            }
          
            if (!PackageId.IsNullOrWhiteSpace())
            {
                _packageName = PackageId;
            }

            if (!Source.IsNullOrWhiteSpace())
            {
                _packageName = Path.GetFileName(Path.GetDirectoryName(Source));
            }

            return _packageName;
        }
        set => _packageName = value;
    }

    /// <summary>
    /// Gets or sets the package view.
    /// </summary>
    /// <value>
    /// The package view.
    /// </value>
    [DataMember(Name = "packageView")]
    public string? PackageView { get; set; }

    /// <summary>
    /// Gets or sets the source path of the manifest.
    /// </summary>
    /// <value>
    /// The source path.
    /// </value>
    /// <remarks>
    /// Gets the full/absolute file path of the manifest, using system directory separators.
    /// </remarks>
    [IgnoreDataMember]
    public string Source { get; set; } = null!;

    /// <summary>
    /// Gets or sets the version of the package.
    /// </summary>
    /// <value>
    /// The version of the package.
    /// </value>
    [DataMember(Name = "version")]
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the assembly name to get the package version from.
    /// </summary>
    /// <value>
    /// The assembly name to get the package version from.
    /// </value>
    [DataMember(Name = "versionAssemblyName")]
    public string? VersionAssemblyName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether telemetry is allowed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if package telemetry is allowed; otherwise, <c>false</c>.
    /// </value>
    [DataMember(Name = "allowPackageTelemetry")]
    public bool AllowPackageTelemetry { get; set; } = true;

    /// <summary>
    /// Gets or sets the bundle options.
    /// </summary>
    /// <value>
    /// The bundle options.
    /// </value>
    [DataMember(Name = "bundleOptions")]
    public BundleOptions BundleOptions { get; set; }

    /// <summary>
    /// Gets or sets the scripts listed in the manifest.
    /// </summary>
    /// <value>
    /// The scripts.
    /// </value>
    [DataMember(Name = "javascript")]
    public string[] Scripts { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Gets or sets the stylesheets listed in the manifest.
    /// </summary>
    /// <value>
    /// The stylesheets.
    /// </value>
    [DataMember(Name = "css")]
    public string[] Stylesheets { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Gets or sets the property editors listed in the manifest.
    /// </summary>
    /// <value>
    /// The property editors.
    /// </value>
    [DataMember(Name = "propertyEditors")]
    public IDataEditor[] PropertyEditors { get; set; } = Array.Empty<IDataEditor>();

    /// <summary>
    /// Gets or sets the parameter editors listed in the manifest.
    /// </summary>
    /// <value>
    /// The parameter editors.
    /// </value>
    [DataMember(Name = "parameterEditors")]
    public IDataEditor[] ParameterEditors { get; set; } = Array.Empty<IDataEditor>();

    /// <summary>
    /// Gets or sets the grid editors listed in the manifest.
    /// </summary>
    /// <value>
    /// The grid editors.
    /// </value>
    [DataMember(Name = "gridEditors")]
    public GridEditor[] GridEditors { get; set; } = Array.Empty<GridEditor>();

    /// <summary>
    /// Gets or sets the content apps listed in the manifest.
    /// </summary>
    /// <value>
    /// The content apps.
    /// </value>
    [DataMember(Name = "contentApps")]
    public ManifestContentAppDefinition[] ContentApps { get; set; } = Array.Empty<ManifestContentAppDefinition>();

    /// <summary>
    /// Gets or sets the dashboards listed in the manifest.
    /// </summary>
    /// <value>
    /// The dashboards.
    /// </value>
    [DataMember(Name = "dashboards")]
    public ManifestDashboard[] Dashboards { get; set; } = Array.Empty<ManifestDashboard>();

    /// <summary>
    /// Gets or sets the sections listed in the manifest.
    /// </summary>
    /// <value>
    /// The sections.
    /// </value>
    [DataMember(Name = "sections")]
    public ManifestSection[] Sections { get; set; } = Array.Empty<ManifestSection>();
}

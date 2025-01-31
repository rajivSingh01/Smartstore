﻿using Smartstore.Core.DataExchange;
using Smartstore.Utilities;

namespace Smartstore.Engine.Modularity
{
    public interface IProviderMetadata
    {
        /// <summary>
        /// Gets the provider system name
        /// </summary>
        string SystemName { get; }

        /// <summary>
        /// Gets the resource key pattern for user data (e.g. FriendlyName)
        /// </summary>
        /// <example>
        /// Plugins.{1}.{0} > 0 = provider system name, 1 = propertyname
        /// </example>
        string ResourceKeyPattern { get; }

        /// <summary>
        /// Gets the provider friendly name
        /// </summary>
        string FriendlyName { get; }

        /// <summary>
        /// Gets the provider description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the provider display order
        /// </summary>
        int DisplayOrder { get; }
    }

    public class ProviderMetadata : IProviderMetadata
    {
        /// <summary>
        /// Gets or sets the provider type
        /// </summary>
        public Type ProviderType { get; set; }

        /// <summary>
        /// Gets or sets the provider's group name
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the provider system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the provider concrete implementation type.
        /// </summary>
        public Type ImplType { get; set; }

        /// <summary>
        /// Gets or sets the resource key pattern for user data (e.g. FriendlyName)
        /// </summary>
        /// <example>
        /// Plugins.{1}.{0} > 0 = provider system name, 1 = propertyname
        /// </example>
        public string ResourceKeyPattern { get; set; }

        /// <summary>
        /// Gets or sets the setting key pattern for user data (e.g. DisplayOrder)
        /// </summary>
        /// <example>
        /// Plugins.{0}.{1} > 0 = provider system name, 1 = propertyname
        /// </example>
        public string SettingKeyPattern { get; set; }

        /// <summary>
        /// Gets or sets the provider friendly name
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the provider description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the provider is configurable (by implementing <see cref="IConfigurable"/>)
        /// </summary>
        public bool IsConfigurable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the provider is editable by the user (by implementing <see cref="IUserEditable"/>)
        /// </summary>
        /// <remarks>
        /// A provider is editable if the user is allowed to change display order and/or localize display name
        /// </remarks>
        public bool IsEditable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the provider is hidden (by decorating with <see cref="IsHiddenAttribute"/>)
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets flags that reflects what features of export data processing is supported by a provider.
        /// </summary>
        public ExportFeatures ExportFeatures { get; set; }

        /// <summary>
        /// Gets or sets an array of widget system names, which depend on the current provider
        /// </summary>
        /// <remarks>
        /// Dependent widgets get automatically (de)activated when their parent providers get (de)activated
        /// </remarks>
        public string[] DependentWidgets { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IModuleDescriptor"/> instance in which the provider is implemented
        /// </summary>
        /// <remarks>The value is <c>null</c>, if the provider is part of the application core</remarks>
        public IModuleDescriptor ModuleDescriptor { get; set; }

        public string GetSettingKey(string name)
        {
            return SettingKeyPattern.FormatCurrent(SystemName, name);
        }

        public override string ToString()
        {
            return "Provider '{0}' - {1}".FormatCurrent(SystemName, FriendlyName);
        }

        public override bool Equals(object obj)
        {
            var other = obj as ProviderMetadata;
            return other != null &&
                SystemName != null &&
                SystemName.Equals(other.SystemName);
        }

        public override int GetHashCode()
        {
            return HashCodeCombiner
                .Start()
                .Add(typeof(ProviderMetadata))
                .Add(SystemName)
                .CombinedHash;
        }
    }
}
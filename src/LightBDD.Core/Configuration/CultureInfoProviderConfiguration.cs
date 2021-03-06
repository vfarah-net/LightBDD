﻿using System;
using System.Diagnostics;
using LightBDD.Core.Extensibility;

namespace LightBDD.Core.Configuration
{
    /// <summary>
    /// Culture info provider configuration.
    /// </summary>
    [DebuggerStepThrough]
    public class CultureInfoProviderConfiguration : FeatureConfiguration
    {
        /// <summary>
        /// Default constructor configuring <see cref="DefaultCultureInfoProvider"/> as CultureInfoProvider.
        /// </summary>
        public CultureInfoProviderConfiguration()
        {
            CultureInfoProvider = new DefaultCultureInfoProvider();
        }

        /// <summary>
        /// Culture info provider.
        /// </summary>
        public ICultureInfoProvider CultureInfoProvider { get; private set; }

        /// <summary>
        /// Updates current culture info provider.
        /// </summary>
        /// <param name="provider">New provider instance to set.</param>
        /// <returns>Self.</returns>
        public CultureInfoProviderConfiguration UpdateCultureInfoProvider(ICultureInfoProvider provider)
        {
            ThrowIfSealed();
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));
            CultureInfoProvider = provider;
            return this;
        }
    }
}
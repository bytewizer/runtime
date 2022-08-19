// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging
#else
namespace Bytewizer.TinyCLR.Logging
#endif
{
    /// <summary>
    /// Identifies a logging event. The primary identifier is the "Id" property, with 
    /// the "Name" property providing a short description of this type of event.
    /// </summary>
    public readonly struct EventId
    {
        /// <summary>
        /// Initializes an instance of the <see cref="EventId"/> struct.
        /// </summary>
        /// <param name="id">The numeric identifier for this event.</param>
        /// <param name="name">The name of this event.</param>
        public EventId(int id, string name = null)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the numeric identifier for this event.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the name of this event.
        /// </summary>
        public string Name { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name ?? Id.ToString();
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Id;
        }
    }
}

// Global aliases to resolve decompiler ambiguities.
// All framework code uses SexyFramework's own Buffer type;
// System.Buffer (static utility) is never used.
global using Buffer = SexyFramework.Misc.Buffer;
// 'Graphics' as a type always means SexyFramework's Graphics class.
// (Microsoft.Xna.Framework.Graphics is a namespace, never used as a type.)
global using Graphics = SexyFramework.Graphics.Graphics;

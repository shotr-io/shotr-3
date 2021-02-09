using System;
using System.Collections.Generic;

namespace Shotr.Core.MimeDetect
{ 
    public class Node
    {
        public string Mime => _mime;
        public string Extension => _extension;
        public FileTypeEnum FileType => _fileType;
        
        private string _mime;
        private string _extension;
        private FileTypeEnum _fileType;
        
        private Func<byte[], bool> _matcher;
        private List<Node> _children;
        
        public Node(FileTypeEnum type, string mime, string extension, Func<byte[], bool> matcher, params Node[] children)
        {
            _fileType = type;
            _mime = mime;
            _extension = extension;
            _matcher = matcher;
            _children = new List<Node>(children);
        }

        public void Append(params Node[] children)
        {
            foreach (var node in children)
            {
                _children.Add(node);
            }
        }

        public Node Match(byte[] file, Node deepestMatch)
        {
            foreach (var node in _children)
            {
                if (node._matcher.Invoke(file))
                {
                    return node.Match(file, node);
                }
            }

            return deepestMatch;
        }

        public string Tree()
        {
            string PrintTree(Node n, int level)
            {
                var offset = "";
                for (var i = 0; i < level; i++)
                {
                    offset += "|\t";
                }

                if (n._children.Count > 0)
                {
                    offset += "+";
                }

                var fmt = $"{offset}{n.Mime} \n";
                foreach (var node in n._children)
                {
                    fmt += PrintTree(node, level + 1);
                }

                return fmt;
            }

            return PrintTree(this, 0);
        }

        public string? GetMimeForFileExt(Node? node, string ext)
        {
            foreach (var child in node?._children ?? _children)
            {
                if (child.Extension == ext)
                {
                    return child.Mime;
                }

                if (child._children.Count > 0)
                {
                    var ret = GetMimeForFileExt(child, ext);
                    if (ret is { })
                    {
                        return ret;
                    }
                }
            }
            // Couldn't find mime?
            return null;
        }

        public string? GetFileExtForMime(Node? node, string mime)
        {
            foreach (var child in node?._children ?? _children)
            {
                if (child.Mime == mime)
                {
                    return child.Extension;
                }

                if (child._children.Count > 0)
                {
                    return GetFileExtForMime(child, mime);
                }
            }
            // Couldn't find ext?
            return null;
        }
    }
}
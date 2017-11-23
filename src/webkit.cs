//
// Copyright 2010, Novell, Inc.
// Copyright 2010, Alexander Shulgin
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using XamCore.Foundation;
using XamCore.AppKit;
using XamCore.CoreGraphics;
using XamCore.ObjCRuntime;
#if XAMCORE_2_0
using JavaScriptCore;
#endif

namespace XamCore.WebKit {

	[BaseType (typeof (WebScriptObject), Name="DOMObject")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMObject init]: should never be used
	partial interface DomObject : NSCopying {
	}

	/////////////////////////
	// DomObject subclasses

	[BaseType (typeof (DomObject), Name="DOMAbstractView")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMAbstractView init]: should never be used
	partial interface DomAbstractView {
		[Export ("document", ArgumentSemantic.Retain)]
		DomDocument Document { get; }
	}

	[BaseType (typeof (DomObject), Name="DOMCSSRule")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMCSSRule init]: should never be used
	partial interface DomCssRule {
		[Export ("type")]
		DomCssRuleType Type { get; }

		[Export ("cssText", ArgumentSemantic.Copy)]
		string CssText { get; set; }

		[Export ("parentStyleSheet", ArgumentSemantic.Retain)]
		DomCssStyleSheet ParentStyleSheet { get;  }

		[Export ("parentRule", ArgumentSemantic.Retain)]
		DomCssRule ParentRule { get;  }
	}

	[BaseType (typeof (DomCssRule), Name="DOMCSSCharsetRule")]
	[DisableDefaultCtor]
	partial interface DomCssCharsetRule {
		[Export ("encoding")]
		string Encoding { get; }
	}

	[BaseType (typeof (DomCssRule), Name="DOMCSSFontFaceRule")]
	[DisableDefaultCtor]
	partial interface DomCssFontFaceRule {
		[Export ("style", ArgumentSemantic.Strong)]
		DomCssStyleDeclaration Style { get; }
	}

	[BaseType (typeof (DomCssRule), Name="DOMCSSImportRule")]
	[DisableDefaultCtor]
	partial interface DomImportCssRule {
		[Export ("href")]
		string Href { get; }

		[Export ("media", ArgumentSemantic.Strong)]
		DomMediaList Media { get; }

		[Export ("styleSheet", ArgumentSemantic.Strong)]
		DomCssStyleSheet StyleSheet { get; }
	}

	[BaseType (typeof (DomCssRule), Name="DOMCSSMediaRule")]
	[DisableDefaultCtor]
	partial interface DomCssMediaRule {
		[Export ("media", ArgumentSemantic.Strong)]
		DomMediaList Media { get; }

		[Export ("cssRules", ArgumentSemantic.Strong)]
		DomCssRuleList CssRules { get; }

		[Export ("insertRule:index:")]
		uint InsertRule (string rule, uint index);

		[Export ("deleteRule:")]
		void DeleteRule (uint index);
	}

	[BaseType (typeof (DomCssRule), Name="DOMCSSPageRule")]
	[DisableDefaultCtor]
	partial interface DomCssPageRule {
		[Export ("selectorText")]
		string SelectorText { get; }

		[Export ("style", ArgumentSemantic.Strong)]
		DomCssStyleDeclaration Style { get; }
	}

	[BaseType (typeof (DomCssRule), Name="DOMCSSStyleRule")]
	[DisableDefaultCtor]
	partial interface DomCssStyleRule {
		[Export ("selectorText")]
		string SelectorText { get; }

		[Export ("style", ArgumentSemantic.Strong)]
		DomCssStyleDeclaration Style { get; }
	}
	
	[BaseType (typeof (DomCssRule), Name="DOMCSSUnknownRule")]
	[DisableDefaultCtor]
	partial interface DomCssUnknownRule {
	}

	[BaseType (typeof (DomObject), Name="DOMCSSRuleList")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMCSSRuleList init]: should never be used
	partial interface DomCssRuleList {
		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("item:")]
		DomCssRule GetItem (int /* unsigned int */ index);
	}

	[BaseType (typeof (DomObject), Name="DOMCSSStyleDeclaration")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMCSSStyleDeclaration init]: should never be used
	partial interface DomCssStyleDeclaration {
		[Export ("cssText", ArgumentSemantic.Copy)]
		string CssText { get; set; }

		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("parentRule", ArgumentSemantic.Retain)]
		DomCssRule ParentRule { get;  }

		[Export ("getPropertyValue:")]
		string GetPropertyValue (string propertyName);

		[Export ("getPropertyCSSValue:")]
		DomCssValue GetPropertyCssValue (string propertyName);

		[Export ("removeProperty:")]
		string RemoveProperty (string propertyName);

		[Export ("getPropertyPriority:")]
		string GetPropertyPriority (string propertyName);

		[Export ("setProperty:value:priority:")]
		void SetProperty (string propertyName, string value, string priority);

		[Export ("item:")]
		string GetItem (int /* unsigned int */ index);

		[Export ("getPropertyShorthand:")]
		string GetPropertyShorthand (string propertyName);

		[Export ("isPropertyImplicit:")]
		bool IsPropertyImplicit (string propertyName);
	}

	[BaseType (typeof (DomStyleSheet), Name="DOMCSSStyleSheet")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMCSSStyleSheet init]: should never be used
	partial interface DomCssStyleSheet {
		[Export ("ownerRule", ArgumentSemantic.Retain)]
		DomCssRule OwnerRule { get; }
	
		[Export ("cssRules", ArgumentSemantic.Retain)]
		DomCssRuleList CssRules { get;  }

		[Export ("rules", ArgumentSemantic.Retain)]
		DomCssRuleList Rules { get;  }

		[Export ("insertRule:index:")]
		uint /* unsigned int */ InsertRule (string rule, uint /* unsigned int */ index);

		[Export ("deleteRule:")]
		void DeleteRule (uint /* unsigned int */ index);

		[Export ("addRule:style:index:")]
		int /* int, not NSInteger */ AddRule (string selector, string style, uint /* unsigned int */ index);

		[Export ("removeRule:")]
		void RemoveRule (uint /* unsigned int */ index);
	}

	[BaseType (typeof (DomObject), Name="DOMCSSValue")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMCSSValue init]: should never be used
	partial interface DomCssValue {
		[Export ("cssText", ArgumentSemantic.Copy)]
		string CssText { get; set; }

		[Export ("cssValueType")]
		DomCssValueType Type { get; }
	}

	[BaseType (typeof (DomObject), Name="DOMHTMLCollection")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMHTMLCollection init]: should never be used
	partial interface DomHtmlCollection {
		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("item:")]
		DomNode GetItem (int /* unsigned int */ index);

		[Export ("namedItem:")]
		DomNode GetNamedItem (string name);

		[Export ("tags:")]
		DomNodeList GetTags (string name);
	}

	[BaseType (typeof (DomObject), Name="DOMImplementation")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMImplementation init]: should never be used
	partial interface DomImplementation {
		[Export ("hasFeature:version:")]
		bool HasFeature (string feature, string version);

		[Export ("createDocumentType:publicId:systemId:")]
		DomDocumentType CreateDocumentType (string qualifiedName, string publicId, string systemId);

		[Export ("createDocument:qualifiedName:doctype:")]
		DomDocument CreateDocument (string namespaceUri, string qualifiedName, DomDocumentType doctype);

		[Export ("createCSSStyleSheet:media:")]
		DomCssStyleSheet CreateCssStyleSheet (string title, string media);

		[Export ("createHTMLDocument:")]
		DomHtmlDocument CreateHtmlDocument (string title);
	}

	[BaseType (typeof (DomObject), Name="DOMMediaList")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMMediaList init]: should never be used
	partial interface DomMediaList {
		[Export ("mediaText", ArgumentSemantic.Copy)]
		string MediaText { get; set; }

		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("item:")]
		string GetItem (int /* unsigned int */ index);

		[Export ("deleteMedium:")]
		void DeleteMedium (string oldMedium);

		[Export ("appendMedium:")]
		void AppendMedium (string newMedium);
	}

	[BaseType (typeof (DomObject), Name="DOMNamedNodeMap")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMNamedNodeMap init]: should never be used
	partial interface DomNamedNodeMap {
		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("getNamedItem:")]
		DomNode GetNamedItem (string name);

		[Export ("setNamedItem:")]
		DomNode SetNamedItem (DomNode node);

		[Export ("removeNamedItem:")]
		DomNode RemoveNamedItem (string name);

		[Export ("item:")]
		DomNode GetItem (int /* unsigned int */ index);

		[Export ("getNamedItemNS:localName:")]
		DomNode GetNamedItemNS (string namespaceUri, string localName);

		[Export ("setNamedItemNS:")]
		DomNode SetNamedItemNS (DomNode node);

		[Export ("removeNamedItemNS:localName:")]
		DomNode RemoveNamedItemNS (string namespaceURI, string localName);
	}

	[BaseType (typeof (DomObject), Name="DOMNode")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMNode init]: should never be used
	partial interface DomNode : DomEventTarget {
		[Export ("nodeName", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("nodeValue", ArgumentSemantic.Copy)]
		string NodeValue { get; set; }

		[Export ("nodeType")]
		DomNodeType NodeType { get;  }

		[Export ("parentNode", ArgumentSemantic.Retain)]
		DomNode ParentNode { get;  }

		[Export ("childNodes", ArgumentSemantic.Retain)]
		DomNodeList ChildNodes { get;  }

		[Export ("firstChild", ArgumentSemantic.Retain)]
		DomNode FirstChild { get;  }

		[Export ("lastChild", ArgumentSemantic.Retain)]
		DomNode LastChild { get;  }

		[Export ("previousSibling", ArgumentSemantic.Retain)]
		DomNode PreviousSibling { get;  }

		[Export ("nextSibling", ArgumentSemantic.Retain)]
		DomNode NextSibling { get;  }

		[Export ("attributes", ArgumentSemantic.Retain)]
		DomNamedNodeMap Attributes { get;  }

		[Export ("ownerDocument", ArgumentSemantic.Retain)]
		DomDocument OwnerDocument { get;  }

		[Export ("namespaceURI", ArgumentSemantic.Copy)]
		string NamespaceURI { get;  }

		[Export ("prefix", ArgumentSemantic.Copy)]
		string Prefix { get; set;  }

		[Export ("localName", ArgumentSemantic.Copy)]
		string LocalName { get;  }

		[Export ("baseURI", ArgumentSemantic.Copy)]
		string BaseURI { get;  }

		[Export ("textContent", ArgumentSemantic.Copy)]
		string TextContent { get; set;  }

		[Export ("parentElement", ArgumentSemantic.Retain)]
		DomElement ParentElement { get;  }

		[Export ("isContentEditable")]
		bool IsContentEditable { get;  }

		[Export ("insertBefore:refChild:")]
		DomNode InsertBefore (DomNode newChild, [NullAllowed] DomNode refChild);

		[Export ("replaceChild:oldChild:")]
		DomNode ReplaceChild (DomNode newChild, DomNode oldChild);

		[Export ("removeChild:")]
		DomNode RemoveChild (DomNode oldChild);

		[Export ("appendChild:")]
		DomNode AppendChild (DomNode newChild);

		[Export ("hasChildNodes")]
		bool HasChildNodes ();

		[Export ("cloneNode:")]
		DomNode CloneNode (bool deep);

		[Export ("normalize")]
		void Normalize ();

		[Export ("isSupported:version:")]
		bool IsSupported (string feature, string version);

		[Export ("hasAttributes")]
		bool HasAttributes ();

		[Export ("isSameNode:")]
		bool IsSameNode ([NullAllowed] DomNode other);

		[Export ("isEqualNode:")]
		bool IsEqualNode ([NullAllowed] DomNode other);

		[Export ("lookupPrefix:")]
		string LookupPrefix (string namespaceURI);

		[Export ("isDefaultNamespace:")]
		bool IsDefaultNamespace (string namespaceURI);

		[Export ("lookupNamespaceURI:")]
		string LookupNamespace (string prefix);

		[Export ("compareDocumentPosition:")]
		DomDocumentPosition CompareDocumentPosition (DomNode other);
	}

	interface IDomNodeFilter {}

	[Mac (10,4)]
	[Protocol, Model]
	[BaseType (typeof (NSObject), Name="DOMNodeFilter")]
	interface DomNodeFilter {
		[Export ("acceptNode:")]
		[Abstract]
		short AcceptNode (DomNode n);
	}

	[Mac (10,4)]
	[BaseType (typeof (DomObject), Name="DOMNodeIterator")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomNodeIterator {
		[Export ("root", ArgumentSemantic.Retain)]
		DomNode Root { get; }

		[Export ("whatToShow")]
		uint WhatToShow { get; } /* unsigned int */

		[Export ("filter", ArgumentSemantic.Retain)]
		IDomNodeFilter Filter { get; }

		[Export ("expandEntityReferences")]
		bool ExpandEntityReferences { get; }

		[Mac (10,5)]
		[Export ("referenceNode", ArgumentSemantic.Retain)]
		DomNode ReferenceNode { get; }

		[Mac (10,5)]
		[Export ("pointerBeforeReferenceNode")]
		bool PointerBeforeReferenceNode { get; }

		[Export ("nextNode")]
		DomNode NextNode { get; }

		[Export ("previousNode")]
		DomNode PreviousNode { get; }

		[Export ("detach")]
		void Detach ();
	}

	[BaseType (typeof (DomObject), Name="DOMNodeList")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMNodeList init]: should never be used
	partial interface DomNodeList {
		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("item:")]
		DomNode GetItem (int /* unsigned int */ index);
	}

	[BaseType (typeof (DomObject), Name="DOMRange")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMRange init]: should never be used
	partial interface DomRange {
		[Export ("startContainer", ArgumentSemantic.Retain)]
		DomNode StartContainer { get;  }

		[Export ("startOffset")]
		int StartOffset { get;  } /* int, not NSInteger */

		[Export ("endContainer", ArgumentSemantic.Retain)]
		DomNode EndContainer { get;  }

		[Export ("endOffset")]
		int EndOffset { get;  } /* int, not NSInteger */ 

		[Export ("collapsed")]
		bool Collapsed { get;  }

		[Export ("commonAncestorContainer", ArgumentSemantic.Retain)]
		DomNode CommonAncestorContainer { get;  }

		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get;  }

		[Export ("setStart:offset:")]
		void SetStart (DomNode refNode, int /* int, not NSInteger */ offset );

		[Export ("setEnd:offset:")]
		void SetEnd (DomNode refNode, int /* int, not NSInteger */ offset);

		[Export ("setStartBefore:")]
		void SetStartBefore (DomNode refNode);

		[Export ("setStartAfter:")]
		void SetStartAfter (DomNode refNode);

		[Export ("setEndBefore:")]
		void SetEndBefore (DomNode refNode);

		[Export ("setEndAfter:")]
		void SetEndAfter (DomNode refNode);

		[Export ("collapse:")]
		void Collapse (bool toStart);

		[Export ("selectNode:")]
		void SelectNode (DomNode refNode);

		[Export ("selectNodeContents:")]
		void SelectNodeContents (DomNode refNode);

		[Export ("compareBoundaryPoints:sourceRange:")]
		short CompareBoundaryPoints (DomRangeCompareHow how, DomRange sourceRange);

		[Export ("deleteContents")]
		void DeleteContents ();

		[Export ("extractContents")]
		DomDocumentFragment ExtractContents ();

		[Export ("cloneContents")]
		DomDocumentFragment CloneContents ();

		[Export ("insertNode:")]
		void InsertNode (DomNode newNode);

		[Export ("surroundContents:")]
		void SurroundContents (DomNode newParent);

		[Export ("cloneRange")]
		DomRange CloneRange ();

		[Export ("toString")]
		string ToString ();

		[Export ("detach")]
		void Detach ();

		[Export ("createContextualFragment:")]
		DomDocumentFragment CreateContextualFragment (string html);

		[Export ("intersectsNode:")]
		bool IntersectsNode (DomNode refNode);

		[Export ("compareNode:")]
		short CompareNode (DomNode refNode);

		[Export ("comparePoint:offset:")]
		short ComparePoint (DomNode refNode, int /* int, not NSInteger */ offset);

		[Export ("isPointInRange:offset:")]
		bool IsPointInRange (DomNode refNode, int /* int, not NSInteger */ offset);
	}

	[BaseType (typeof (DomObject), Name="DOMStyleSheet")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMStyleSheet init]: should never be used
	partial interface DomStyleSheet {
		[Export ("type", ArgumentSemantic.Copy)]
		string Type { get; }

		[Export ("disabled")]
		bool Disabled { get; set; }

		[Export ("ownerNode", ArgumentSemantic.Retain)]
		DomNode OwnerNode { get;  }

		[Export ("parentStyleSheet", ArgumentSemantic.Retain)]
		DomStyleSheet ParentStyleSheet { get;  }

		[Export ("href", ArgumentSemantic.Copy)]
		string Href { get;  }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get;  }

		[Export ("media", ArgumentSemantic.Retain)]
		DomMediaList Media { get;  }
	}

	[BaseType (typeof (DomObject), Name="DOMStyleSheetList")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMStyleSheetList init]: should never be used
	partial interface DomStyleSheetList {
		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("item:")]
		DomStyleSheet GetItem (int /* unsigned int */ index);
	}

	///////////////////////
	// DomNode subclasses

	[BaseType (typeof (DomNode), Name="DOMAttr")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMAttr init]: should never be used
	partial interface DomAttr {
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("specified")]
		bool Specified { get; }

		[Export ("value", ArgumentSemantic.Copy)]
		string Value { get; set;  }

		[Export ("ownerElement", ArgumentSemantic.Retain)]
		DomElement OwnerElement { get;  }

		[Export ("style", ArgumentSemantic.Retain)]
		DomCssStyleDeclaration Style { get;  }
	}

	[BaseType (typeof (DomNode), Name="DOMCharacterData")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMCharacterData init]: should never be used
	partial interface DomCharacterData {
		[Export ("data", ArgumentSemantic.Copy)]
		string Data { get; set; }

		[Export ("length")]
		int Count { get; } /* unsigned int */

		[Export ("substringData:length:")]
		string SubstringData (uint /* unsigned int */ offset, uint /* unsigned int */ length);

		[Export ("appendData:")]
		void AppendData (string data);

		[Export ("insertData:data:")]
		void InsertData (uint /* unsigned int */ offset, string data);

		[Export ("deleteData:length:")]
		void DeleteData (uint /* unsigned int */ offset, uint /* unsigned int */ length);

		[Export ("replaceData:length:data:")]
		void ReplaceData (uint /* unsigned int */ offset, uint /* unsigned int */ length, string data);
	}

	[BaseType (typeof (DomNode), Name="DOMDocument")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMDocument init]: should never be used
	partial interface DomDocument {
		[Export ("doctype", ArgumentSemantic.Retain)]
		DomDocumentType DocumentType { get; }

		[Export ("implementation", ArgumentSemantic.Retain)]
		DomImplementation Implementation { get; }

		[Export ("documentElement", ArgumentSemantic.Retain)]
		DomElement DocumentElement { get;  }

		[Export ("inputEncoding", ArgumentSemantic.Copy)]
		string InputEncoding { get;  }

		[Export ("xmlEncoding", ArgumentSemantic.Copy)]
		string XmlEncoding { get;  }

		[Export ("xmlVersion", ArgumentSemantic.Copy)]
		string XmlVersion { get; set; }

		[Export ("xmlStandalone")]
		bool XmlStandalone { get; set;  }

		[Export ("documentURI", ArgumentSemantic.Copy)]
		string DocumentURI { get; set;  }

		[Export ("defaultView", ArgumentSemantic.Retain)]
		DomAbstractView DefaultView { get;  }

		[Export ("styleSheets", ArgumentSemantic.Retain)]
		DomStyleSheetList StyleSheets { get;  }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set;  }

		[Export ("referrer", ArgumentSemantic.Copy)]
		string Referrer { get;  }

		[Export ("domain", ArgumentSemantic.Copy)]
		string Domain { get;  }

		[Export ("URL", ArgumentSemantic.Copy)]
		string Url { get;  }

		[Export ("cookie", ArgumentSemantic.Copy)]
		string Cookie { get; set;  }

		[Export ("body", ArgumentSemantic.Retain)]
		DomHtmlElement body { get; set;  }

		[Export ("images", ArgumentSemantic.Retain)]
		DomHtmlCollection images { get;  }

		[Export ("applets", ArgumentSemantic.Retain)]
		DomHtmlCollection applets { get;  }

		[Export ("links", ArgumentSemantic.Retain)]
		DomHtmlCollection links { get;  }

		[Export ("forms", ArgumentSemantic.Retain)]
		DomHtmlCollection forms { get;  }

		[Export ("anchors", ArgumentSemantic.Retain)]
		DomHtmlCollection anchors { get;  }

		[Export ("lastModified", ArgumentSemantic.Copy)]
		string LastModified { get;  }

		[Export ("charset", ArgumentSemantic.Copy)]
		string Charset { get; set;  }

		[Export ("defaultCharset", ArgumentSemantic.Copy)]
		string DefaultCharset { get;  }

		[Export ("readyState", ArgumentSemantic.Copy)]
		string ReadyState { get;  }

		[Export ("characterSet", ArgumentSemantic.Copy)]
		string CharacterSet { get;  }

		[Export ("preferredStylesheetSet", ArgumentSemantic.Copy)]
		string PreferredStylesheetSet { get;  }

		[Export ("selectedStylesheetSet", ArgumentSemantic.Copy)]
		string SelectedStylesheetSet { get; set;  }

		[Export ("createElement:")]
		DomElement CreateElement (string tagName);

		[Export ("createDocumentFragment")]
		DomDocumentFragment CreateDocumentFragment ();

		[Export ("createTextNode:")]
		DomText CreateTextNode (string data);

		[Export ("createComment:")]
		DomComment CreateComment (string data);

		[Export ("createCDATASection:")]
		DomCDataSection CreateCDataSection (string data);

		[Export ("createProcessingInstruction:data:")]
		DomProcessingInstruction CreateProcessingInstruction (string target, string data);

		[Export ("createAttribute:")]
		DomAttr CreateAttribute (string name);

		[Export ("createEntityReference:")]
		DomEntityReference CreateEntityReference (string name);

		[Export ("getElementsByTagName:")]
		DomNodeList GetElementsByTagName (string tagname);

		[Export ("importNode:deep:")]
		DomNode ImportNode (DomNode importedNode, bool deep);

		[Export ("createElementNS:qualifiedName:")]
		DomElement CreateElementNS (string namespaceURI, string qualifiedName);

		[Export ("createAttributeNS:qualifiedName:")]
		DomAttr CreateAttributeNS (string namespaceURI, string qualifiedName);

		[Export ("getElementsByTagNameNS:localName:")]
		DomNodeList GetElementsByTagNameNS (string namespaceURI, string localName);

		[Export ("getElementById:")]
		DomElement GetElementById (string elementId);

		[Export ("adoptNode:")]
		DomNode AdoptNode (DomNode source);

		[Export ("createEvent:")]
		DomEvent CreateEvent (string eventType);

		[Export ("createRange")]
		DomRange CreateRange ();

		[Export ("createNodeIterator:whatToShow:filter:expandEntityReferences:")]
		DomNodeIterator CreateNodeIterator (DomNode root, uint /* unsigned int */ whatToShow, IDomNodeFilter filter, bool expandEntityReferences);

		//[Export ("createTreeWalker:whatToShow:filter:expandEntityReferences:")]
		//DomTreeWalker CreateTreeWalker (DomNode root, unsigned whatToShow, id <DomNodeFilter> filter, bool expandEntityReferences);

		[Export ("getOverrideStyle:pseudoElement:")]
		DomCssStyleDeclaration GetOverrideStyle (DomElement element, string pseudoElement);

		//[Export ("createExpression:resolver:")]
		//DomXPathExpression CreateExpression (string expression, id <DomXPathNSResolver> resolver);

		//[Export ("createNSResolver:")]
		//id <DomXPathNSResolver> CreateNSResolver (DomNode nodeResolver);

		//[Export ("evaluate:contextNode:resolver:type:inResult:")]
		//DomXPathResult Evaluate (string expression, DomNode contextNode, id <DomXPathNSResolver> resolver, unsigned short type, DomXPathResult inResult);

		[Export ("execCommand:userInterface:value:")]
		bool ExecCommand (string command, bool userInterface, string value);

		[Export ("execCommand:userInterface:")]
		bool ExecCommand (string command, bool userInterface);

		[Export ("execCommand:")]
		bool ExecCommand (string command);

		[Export ("queryCommandEnabled:")]
		bool QueryCommandEnabled (string command);

		[Export ("queryCommandIndeterm:")]
		bool QueryCommandIndeterm (string command);

		[Export ("queryCommandState:")]
		bool QueryCommandState (string command);

		[Export ("queryCommandSupported:")]
		bool QueryCommandSupported (string command);

		[Export ("queryCommandValue:")]
		string QueryCommandValue (string command);

		[Export ("getElementsByName:")]
		DomNodeList GetElementsByName (string elementName);

		[Export ("elementFromPoint:y:")]
		DomElement ElementFromPoint (int /* int, not NSInteger */ x, int /* int, not NSInteger */ y);

		[Export ("createCSSStyleDeclaration")]
		DomCssStyleDeclaration CreateCssStyleDeclaration ();

		[Export ("getComputedStyle:pseudoElement:")]
		DomCssStyleDeclaration GetComputedStyle (DomElement element, string pseudoElement);

		[Export ("getMatchedCSSRules:pseudoElement:")]
		DomCssRuleList GetMatchedCSSRules (DomElement element, string pseudoElement);

		[Export ("getMatchedCSSRules:pseudoElement:authorOnly:")]
		DomCssRuleList GetMatchedCSSRules (DomElement element, string pseudoElement, bool authorOnly);

		[Export ("getElementsByClassName:")]
		DomNodeList GetElementsByClassName (string tagname);

		[Export ("querySelector:")]
		DomElement QuerySelector (string selectors);

		[Export ("querySelectorAll:")]
		DomNodeList QuerySelectorAll (string selectors);
	}

	[BaseType (typeof (DomNode), Name="DOMDocumentFragment")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMDocumentFragment init]: should never be used
	partial interface DomDocumentFragment {
	}

	[BaseType (typeof (DomNode), Name="DOMDocumentType")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMDocumentType init]: should never be used
	partial interface DomDocumentType {
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get;  }

		[Export ("entities", ArgumentSemantic.Retain)]
		DomNamedNodeMap Entities { get;  }

		[Export ("notations", ArgumentSemantic.Retain)]
		DomNamedNodeMap Notations { get;  }

		[Export ("publicId", ArgumentSemantic.Copy)]
		string PublicId { get;  }

		[Export ("systemId", ArgumentSemantic.Copy)]
		string SystemId { get;  }

		[Export ("internalSubset", ArgumentSemantic.Copy)]
		string InternalSubset { get;  }

	}
	
	[BaseType (typeof (DomNode), Name="DOMElement")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMElement init]: should never be used
	partial interface DomElement {
		[Export ("tagName", ArgumentSemantic.Copy)]
		string TagName { get; }

		[Export ("style", ArgumentSemantic.Retain)]
		DomCssStyleDeclaration Style { get; }

		[Export ("offsetLeft")]
		int OffsetLeft { get; } /* int, not NSInteger */

		[Export ("offsetTop")]
		int OffsetTop { get; } /* int, not NSInteger */

		[Export ("offsetWidth")]
		int OffsetWidth { get; } /* int, not NSInteger */

		[Export ("offsetHeight")]
		int OffsetHeight { get; } /* int, not NSInteger */

		[Export ("offsetParent", ArgumentSemantic.Retain)]
		DomElement OffsetParent { get;  }

		[Export ("clientLeft")]
		int ClientLeft { get; } /* int, not NSInteger */

		[Export ("clientTop")]
		int ClientTop { get; } /* int, not NSInteger */

		[Export ("clientWidth")]
		int ClientWidth { get; } /* int, not NSInteger */

		[Export ("clientHeight")]
		int ClientHeight { get; } /* int, not NSInteger */

		[Export ("scrollLeft")]
		int ScrollLeft { get; set; } /* int, not NSInteger */

		[Export ("scrollTop")]
		int ScrollTop { get; set; } /* int, not NSInteger */

		[Export ("scrollWidth")]
		int ScrollWidth { get; } /* int, not NSInteger */

		[Export ("scrollHeight")]
		int ScrollHeight { get; } /* int, not NSInteger */

		[Mavericks, Export ("className", ArgumentSemantic.Copy)]
		string ClassName { get; set; }

		[Export ("firstElementChild", ArgumentSemantic.Retain)]
		DomElement FirstElementChild { get;  }

		[Export ("lastElementChild", ArgumentSemantic.Retain)]
		DomElement LastElementChild { get;  }

		[Export ("previousElementSibling", ArgumentSemantic.Retain)]
		DomElement PreviousElementSibling { get;  }

		[Export ("nextElementSibling", ArgumentSemantic.Retain)]
		DomElement NextElementSibling { get;  }

		[Export ("childElementCount")]
		uint ChildElementCount { get; } /* unsigned int */

		[Export ("innerText", ArgumentSemantic.Copy)]
		string InnerText { get;  }

		[Export ("getAttribute:")]
		string GetAttribute (string name);

		[Export ("setAttribute:value:")]
		void SetAttribute (string name, string value);

		[Export ("removeAttribute:")]
		void RemoveAttribute (string name);

		[Export ("getAttributeNode:")]
		DomAttr GetAttributeNode (string name);

		[Export ("setAttributeNode:")]
		DomAttr SetAttributeNode (DomAttr newAttr);

		[Export ("removeAttributeNode:")]
		DomAttr RemoveAttributeNode (DomAttr oldAttr);

		[Export ("getElementsByTagName:")]
		DomNodeList GetElementsByTagName (string name);

		[Export ("getAttributeNS:localName:")]
		string GetAttributeNS (string namespaceURI, string localName);

		[Export ("setAttributeNS:qualifiedName:value:")]
		void SetAttributeNS (string namespaceURI, string qualifiedName, string value);

		[Export ("removeAttributeNS:localName:")]
		void RemoveAttributeNS (string namespaceURI, string localName);

		[Export ("getElementsByTagNameNS:localName:")]
		DomNodeList GetElementsByTagNameNS (string namespaceURI, string localName);

		[Export ("getAttributeNodeNS:localName:")]
		DomAttr GetAttributeNodeNS (string namespaceURI, string localName);

		[Export ("setAttributeNodeNS:")]
		DomAttr SetAttributeNodeNS (DomAttr newAttr);

		[Export ("hasAttribute:")]
		bool HasAttribute (string name);

		[Export ("hasAttributeNS:localName:")]
		bool HasAttributeNS (string namespaceURI, string localName);

		[Export ("focus")]
		void Focus ();

		[Export ("blur")]
		void Blur ();

		[Export ("scrollIntoView:")]
		void ScrollIntoView (bool alignWithTop);

		[Export ("contains:")]
		bool Contains (DomElement element);

		[Export ("scrollIntoViewIfNeeded:")]
		void ScrollIntoViewIfNeeded (bool centerIfNeeded);

		[Export ("scrollByLines:")]
		void ScrollByLines (int /* int, not NSInteger */ lines);

		[Export ("scrollByPages:")]
		void ScrollByPages (int /* int, not NSInteger */ pages);

		[Export ("getElementsByClassName:")]
		DomNodeList GetElementsByClassName (string name);

		[Export ("querySelector:")]
		DomElement QuerySelector (string selectors);

		[Export ("querySelectorAll:")]
		DomNodeList QuerySelectorAll (string selectors);

		[Export ("webkitRequestFullScreen:")]
		void WebKitRequestFullScreen (ushort flags);
	}

	[BaseType (typeof (DomNode), Name="DOMEntityReference")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMEntityReference init]: should never be used
	partial interface DomEntityReference {
	}

	[BaseType (typeof (NSObject), Name = "DOMEventTarget")]
	[Protocol]
	[Model]
	partial interface DomEventTarget : NSCopying
	{
		[Export ("addEventListener:listener:useCapture:")]
#if XAMCORE_2_0
		[Abstract]
		void AddEventListener (string type, IDomEventListener listener, bool useCapture);
#else
		void AddEventListener (string type, DomEventListener listener, bool useCapture);
#endif

		[Export ("removeEventListener:listener:useCapture:")]
#if XAMCORE_2_0
		[Abstract]
		void RemoveEventListener (string type, IDomEventListener listener, bool useCapture);
#else
		void RemoveEventListener (string type, DomEventListener listener, bool useCapture);
#endif

		[Export ("dispatchEvent:")]
#if XAMCORE_2_0
		[Abstract]
#endif
		bool DispatchEvent (DomEvent evt);
	}

	[BaseType (typeof (DomObject), Name="DOMEvent")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMEvent init]: should never be used
	partial interface DomEvent {
		[Export ("type", ArgumentSemantic.Copy)]
		string Type { get; }

		[Export ("target", ArgumentSemantic.Retain)]
		[Protocolize]
		DomEventTarget Target { get;  }

		[Export ("currentTarget", ArgumentSemantic.Retain)]
		[Protocolize]
		DomEventTarget CurrentTarget { get;  }

		[Export ("eventPhase")]
		DomEventPhase EventPhase { get;  }

		[Export ("bubbles")]
		bool Bubbles { get;  }

		[Export ("cancelable")]
		bool Cancelable { get;  }

		[Export ("timeStamp")]
		UInt64 TimeStamp { get;  }

		[Export ("srcElement", ArgumentSemantic.Retain)]
		[Protocolize]
		DomEventTarget SourceElement { get;  }

		[Export ("returnValue")]
		bool ReturnValue { get; set;  }

		[Export ("cancelBubble")]
		bool CancelBubble { get; set;  }

		[Export ("stopPropagation")]
		void StopPropagation ();

		[Export ("preventDefault")]
		void PreventDefault ();

#if !XAMCORE_3_0
		[Obsolete ("Use the constructor instead.")]
		[Export ("initEvent:canBubbleArg:cancelableArg:")]
		void InitEvent (string eventTypeArg, bool canBubbleArg, bool cancelableArg);
#endif

		[Sealed] // Just to avoid the duplicate selector error
		[Export ("initEvent:canBubbleArg:cancelableArg:")]
		IntPtr Constructor (string eventTypeArg, bool canBubbleArg, bool cancelableArg);
	}

	// Note: DOMMutationEvent is not bound since it is deprecated
	// by the W3C to be replaced with Mutation Observers

	[BaseType (typeof (DomEvent), Name = "DOMOverflowEvent")]
	[DisableDefaultCtor]
	partial interface DomOverflowEvent {
#if !XAMCORE_3_0
		[Obsolete ("Use the constructor instead.")]
		[Export ("initOverflowEvent:horizontalOverflow:verticalOverflow:")]
		void InitEvent (ushort orient, bool hasHorizontalOverflow, bool hasVerticalOverflow);
#endif
		[Sealed] // Just to avoid the duplicate selector error
		[Export ("initOverflowEvent:horizontalOverflow:verticalOverflow:")]
		IntPtr Constructor (ushort orient, bool hasHorizontalOverflow, bool hasVerticalOverflow);

		[Export ("orient")]
		ushort Orient { get; }

		[Export ("horizontalOverflow")]
		bool HasHorizontalOverflow { get; }

		[Export ("verticalOverflow")]
		bool HasVerticalOverflow { get; }
	}

	[BaseType (typeof (DomEvent), Name = "DOMProgressEvent")]
	[DisableDefaultCtor]
	partial interface DomProgressEvent {
		[Export ("lengthComputable")]
		bool IsLengthComputable { get; }

		[Export ("loaded")]
		ulong Loaded { get; }

		[Export ("total")]
		ulong Total { get; }
	}

	[BaseType (typeof (DomEvent), Name = "DOMUIEvent")]
	[DisableDefaultCtor]
	partial interface DomUIEvent {
#if !XAMCORE_3_0
		[Obsolete ("Use the constructor instead.")]
		[Export ("initUIEvent:canBubble:cancelable:view:detail:")]
		void InitEvent (string eventType, bool canBubble, bool cancelable, DomAbstractView view, int /* int, not NSInteger */ detail);
#endif
		[Sealed] // Just to avoid the duplicate selector error
		[Export ("initUIEvent:canBubble:cancelable:view:detail:")]
		IntPtr Constructor (string eventType, bool canBubble, bool cancelable, DomAbstractView view, int /* int, not NSInteger */ detail);

		[Export ("view", ArgumentSemantic.Retain)]
		DomAbstractView View { get; }

		[Export ("detail")]
		int Detail { get; } /* int, not NSInteger */

		[Export ("keyCode")]
		int KeyCode { get; } /* int, not NSInteger */

		[Export ("charCode")]
		int CharCode { get; } /* int, not NSInteger */

		[Export ("layerX")]
		int LayerX { get; } /* int, not NSInteger */

		[Export ("layerY")]
		int LayerY { get; } /* int, not NSInteger */

		[Export ("pageX")]
		int PageX { get; } /* int, not NSInteger */

		[Export ("which")]
		int Which { get; } /* int, not NSInteger */
	}

	[BaseType (typeof (DomUIEvent), Name = "DOMKeyboardEvent")]
	[DisableDefaultCtor]
	partial interface DomKeyboardEvent {
#if !XAMCORE_3_0
		[Obsolete ("Use the constructor instead.")]
		[Export ("initKeyboardEvent:canBubble:cancelable:view:keyIdentifier:keyLocation:ctrlKey:altKey:shiftKey:metaKey:altGraphKey:")]
		void InitEvent (string eventType, bool canBubble, bool cancelable, DomAbstractView view, string keyIdentifier, DomKeyLocation keyLocation, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, bool altGraphKey);

		[Obsolete ("Use the constructor instead.")]
		[Export ("initKeyboardEvent:canBubble:cancelable:view:keyIdentifier:keyLocation:ctrlKey:altKey:shiftKey:metaKey:")]
		void InitEvent (string eventType, bool canBubble, bool cancelable, DomAbstractView view, string keyIdentifier, DomKeyLocation keyLocation, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey);
#endif

		[Sealed] // Just to avoid the duplicate selector error
		[Export ("initKeyboardEvent:canBubble:cancelable:view:keyIdentifier:keyLocation:ctrlKey:altKey:shiftKey:metaKey:altGraphKey:")]
		IntPtr Constructor (string eventType, bool canBubble, bool cancelable, DomAbstractView view, string keyIdentifier, DomKeyLocation keyLocation, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, bool altGraphKey);

		[Sealed] // Just to avoid the duplicate selector error
		[Export ("initKeyboardEvent:canBubble:cancelable:view:keyIdentifier:keyLocation:ctrlKey:altKey:shiftKey:metaKey:")]
		IntPtr Constructor (string eventType, bool canBubble, bool cancelable, DomAbstractView view, string keyIdentifier, DomKeyLocation keyLocation, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey);

		[Export ("getModifierState:")]
		bool GetModifierState (string keyIdentifier);

		[Export ("keyIdentifier", ArgumentSemantic.Copy)]
		string KeyIdentifier { get; }

		[Export ("keyLocation")]
		DomKeyLocation KeyLocation { get; }

		[Export ("ctrlKey")]
		bool CtrlKey { get; }

		[Export ("shiftKey")]
		bool ShiftKey { get; }

		[Export ("altKey")]
		bool AltKey { get; }

		[Export ("metaKey")]
		bool MetaKey { get; }

		[Export ("altGraphKey")]
		bool AltGraphKey { get; }

		[Export ("keyCode")]
		int KeyCode { get; } /* int, not NSInteger */

		[Export ("charCode")]
		int CharCode { get; } /* int, not NSInteger */
	}

	[BaseType (typeof (DomUIEvent), Name = "DOMMouseEvent")]
	[DisableDefaultCtor]
	partial interface DomMouseEvent {
#if !XAMCORE_3_0
		[Obsolete ("Use the constructor instead.")]
		[Export ("initMouseEvent:canBubble:cancelable:view:detail:screenX:screenY:clientX:clientY:ctrlKey:altKey:shiftKey:metaKey:button:relatedTarget:")]
		void InitEvent (string eventType, bool canBubble, bool cancelable, DomAbstractView view, int /* int, not NSInteger */ detail, int /* int, not NSInteger */ screenX, int /* int, not NSInteger */ screenY, int /* int, not NSInteger */ clientX, int /* int, not NSInteger */ clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, ushort button, [Protocolize] DomEventTarget relatedTarget);
#endif
		[Sealed] // Just to avoid the duplicate selector error
		[Export ("initMouseEvent:canBubble:cancelable:view:detail:screenX:screenY:clientX:clientY:ctrlKey:altKey:shiftKey:metaKey:button:relatedTarget:")]
		IntPtr Constructor (string eventType, bool canBubble, bool cancelable, DomAbstractView view, int /* int, not NSInteger */ detail, int /* int, not NSInteger */ screenX, int /* int, not NSInteger */ screenY, int /* int, not NSInteger */ clientX, int /* int, not NSInteger */ clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, ushort button, [Protocolize] DomEventTarget relatedTarget);

		[Export ("screenX")]
		int ScreenX { get; } /* int, not NSInteger */

		[Export ("screenY")]
		int ScreenY { get; } /* int, not NSInteger */

		[Export ("clientX")]
		int ClientX { get; } /* int, not NSInteger */

		[Export ("clientY")]
		int ClientY { get; } /* int, not NSInteger */

		[Export ("ctrlKey")]
		bool CtrlKey { get; }

		[Export ("shiftKey")]
		bool ShiftKey { get; }

		[Export ("altKey")]
		bool AltKey { get; }

		[Export ("metaKey")]
		bool MetaKey { get; }

		[Export ("button")]
		ushort Button { get; }

		[Export ("relatedTarget", ArgumentSemantic.Retain)]
		[Protocolize]
		DomEventTarget RelatedTarget { get; }

		[Export ("offsetX")]
		int OffsetX { get; } /* int, not NSInteger */

		[Export ("offsetY")]
		int OffsetY { get; } /* int, not NSInteger */

		[Export ("x")]
		int X { get; } /* int, not NSInteger */

		[Export ("y")]
		int Y { get; } /* int, not NSInteger */

		[Export ("fromElement", ArgumentSemantic.Retain)]
		DomNode FromElement { get; }

		[Export ("toElement", ArgumentSemantic.Retain)]
		DomNode ToElement { get; }
	}

	[BaseType (typeof (DomMouseEvent), Name = "DOMWheelEvent")]
	[DisableDefaultCtor]
	partial interface DomWheelEvent {
#if !XAMCORE_3_0
		[Obsolete ("Use the constructor instead.")]
		[Export ("initWheelEvent:wheelDeltaY:view:screenX:screenY:clientX:clientY:ctrlKey:altKey:shiftKey:metaKey:")]
		void InitEvent (int /* int, not NSInteger */ wheelDeltaX, int /* int, not NSInteger */ wheelDeltaY, DomAbstractView view, int /* int, not NSInteger */ screenX, int /* int, not NSInteger */ screnY, int /* int, not NSInteger */ clientX, int /* int, not NSInteger */ clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey);
#endif
		[Sealed] // Just to avoid the duplicate selector error
		[Export ("initWheelEvent:wheelDeltaY:view:screenX:screenY:clientX:clientY:ctrlKey:altKey:shiftKey:metaKey:")]
		IntPtr Constructor (int /* int, not NSInteger */ wheelDeltaX, int /* int, not NSInteger */ wheelDeltaY, DomAbstractView view, int /* int, not NSInteger */ screenX, int /* int, not NSInteger */ screnY, int /* int, not NSInteger */ clientX, int /* int, not NSInteger */ clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey);

		[Export ("wheelDeltaX")]
		int WheelDeltaX { get; } /* int, not NSInteger */

		[Export ("wheelDeltaY")]
		int WheelDeltaY { get; } /* int, not NSInteger */

		[Export ("wheelDelta")]
		DomDelta /* int */ WheelDelta { get; }

		[Export ("isHorizontal")]
		bool IsHorizontal { get; }
	}

	[BaseType (typeof (NSObject), Name="DOMEventListener")]
	[Model]
	[Protocol]
	partial interface DomEventListener {
		[Abstract]
		[Export ("handleEvent:")]
		void HandleEvent (DomEvent evt);
	}
	interface IDomEventListener {}
	
	[BaseType (typeof (DomCharacterData), Name="DOMProcessingInstruction")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMProcessingInstruction init]: should never be used
	partial interface DomProcessingInstruction {
		[Export ("target", ArgumentSemantic.Copy)]
		string Target { get; }

		[Export ("data", ArgumentSemantic.Copy)]
		string Data { get; set; }

		[Export ("sheet", ArgumentSemantic.Retain)]
		DomStyleSheet Sheet { get;  }
	}

	////////////////////////////////
	// DomCharacterData subclasses

	[BaseType (typeof (DomCharacterData), Name="DOMText")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMText init]: should never be used
	partial interface DomText {
		[Export("wholeText", ArgumentSemantic.Copy)]
		string WholeText { get; }

		[Export ("splitText:")]
		DomText SplitText (uint /* unsigned int */ offset);

		[Export ("replaceWholeText:")]
		DomText ReplaceWholeText (string content);
	}

	[BaseType (typeof (DomCharacterData), Name="DOMComment")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMComment init]: should never be used
	partial interface DomComment {
	}

	///////////////////////////
	// DomText subclasses

	[BaseType (typeof (DomText), Name="DOMCDATASection")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMCDATASection init]: should never be used
	partial interface DomCDataSection {
	}

	///////////////////////////
	// DomDocument subclasses

	[BaseType (typeof (DomDocument), Name="DOMHTMLDocument")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMHTMLDocument init]: should never be used
	partial interface DomHtmlDocument {
		[Export ("embeds", ArgumentSemantic.Retain)]
		DomHtmlCollection Embeds { get;  }

		[Export ("plugins", ArgumentSemantic.Retain)]
		DomHtmlCollection Plugins { get;  }

		[Export ("scripts", ArgumentSemantic.Retain)]
		DomHtmlCollection Scripts { get;  }

		[Export ("width")]
		int Width { get; } /* int, not NSInteger */

		[Export ("height")]
		int Height { get; } /* int, not NSInteger */

		[Export ("dir", ArgumentSemantic.Copy)]
		string Dir { get; set;  }

		[Export ("designMode", ArgumentSemantic.Copy)]
		string DesignMode { get; set;  }

		[Export ("compatMode", ArgumentSemantic.Copy)]
		string CompatMode { get;  }

		[Export ("activeElement", ArgumentSemantic.Retain)]
		DomElement ActiveElement { get;  }

		[Export ("bgColor", ArgumentSemantic.Copy)]
		string BackgroundColor { get; set;  }

		[Export ("fgColor", ArgumentSemantic.Copy)]
		string ForegroundColor { get; set;  }

		[Export ("alinkColor", ArgumentSemantic.Copy)]
		string ALinkColor { get; set;  }

		[Export ("linkColor", ArgumentSemantic.Copy)]
		string LinkColor { get; set;  }

		[Export ("vlinkColor", ArgumentSemantic.Copy)]
		string VLinkColor { get; set;  }

		[Export ("open")]
		void Open ();

		[Export ("close")]
		void Close ();

		[Export ("write:")]
		void Write (string text);

		[Export ("writeln:")]
		void Writeln (string text);

		[Export ("clear")]
		void Clear ();

		[Export ("captureEvents")]
		void CaptureEvents ();

		[Export ("releaseEvents")]
		void ReleaseEvents ();

		[Export ("hasFocus")]
		bool HasFocus ();
	}

	//////////////////////////
	// DomElement subclasses

	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLInputElement")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMHTMLElement init]: should never be used
	partial interface DomHtmlInputElement {
		[Export ("accept", ArgumentSemantic.Copy)]
		string Accept { get; set; }

		[Export ("alt", ArgumentSemantic.Copy)]
		string Alt { get; set; }

		[Export ("autofocus")]
		bool Autofocus { get; set; }

		[Export ("defaultChecked")]
		bool defaultChecked { get; set; }

		[Export ("checked")]
		bool Checked { get; set; }

		[Export ("disabled")]
		bool Disabled { get; set; }

//		[Export ("form")]
//		DomHtmlFormElement Form { get; }

//		[Export ("files")]
//		DomFileList Files { get; }

		[Export ("indeterminate")]
		bool Indeterminate { get; set; }

		[Export ("maxLength")]
		int MaxLength { get; set; } /* int, not NSInteger */

		[Export ("multiple")]
		bool Multiple { get; set; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		[Export ("readOnly")]
		bool ReadOnly { get; set; }

		[Export ("size", ArgumentSemantic.Copy)]
		string Size { get; set; }

		[Export ("src", ArgumentSemantic.Copy)]
		string Src { get; set; }

		[Export ("type", ArgumentSemantic.Copy)]
		string Type { get; set; }

		[Export ("defaultValue", ArgumentSemantic.Copy)]
		string DefaultValue { get; set; }

		[Export ("value", ArgumentSemantic.Copy)]
		string Value { get; set; }

		[Export ("willValidate")]
		bool WillValidate { get; }

		[Export ("selectionStart")]
		int SelectionStart { get; set; } /* int, not NSInteger */

		[Export ("selectionEnd")]
		int SelectionEnd { get; set; } /* int, not NSInteger */

		[Export ("align", ArgumentSemantic.Copy)]
		string Align { get; set; }

		[Export ("useMap", ArgumentSemantic.Copy)]
		string UseMap { get; set; }
	
		[Export ("accessKey", ArgumentSemantic.Copy)]
		string AccessKey { get; set; }
	
		[Export ("altDisplayString", ArgumentSemantic.Copy)]
		string AltDisplayString { get; }
	
		[Export ("absoluteImageURL", ArgumentSemantic.Copy)]
		NSUrl AbsoluteImageURL { get; }

		[Export ("select")]
		void Select ();

		[Export ("setSelectionRange:end:")]
		void SetSelectionRange (int /* int, not NSInteger */ start, int /* int, not NSInteger */ end);

		[Export ("click")]
		void Click ();
	}

	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLTextAreaElement")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMHTMLElement init]: should never be used
	partial interface DomHtmlTextAreaElement {
	
		[Export ("accessKey", ArgumentSemantic.Copy)]
		string AccessKey { get; set; }

		[Export ("cols")]
		int Columns { get; set; } /* int, not NSInteger */

		[Export ("defaultValue", ArgumentSemantic.Copy)]
		string DefaultValue { get; set; }

		[Export ("disabled")]
		bool Disabled { get; set; }

//		[Export ("form")]
//		DomHtmlFormElement Form { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		[Export ("readOnly")]
		bool ReadOnly { get; set; }

		[Export ("rows")]
		int Rows { get; set; } /* int, not NSInteger */

		[Export ("tabIndex")]
		int TabIndex { get; set; } /* int, not NSInteger */

		[Export ("type", ArgumentSemantic.Copy)]
		string Type { get; }

		[Export ("value", ArgumentSemantic.Copy)]
		string Value { get; set; }

		[Export ("blur")]
		void Blur ();

		[Export ("focus")]
		void Focus ();

		[Export ("select")]
		void Select ();
	}
	
	[BaseType (typeof (DomElement), Name="DOMHTMLElement")]
	[DisableDefaultCtor] // An uncaught exception was raised: +[DOMHTMLElement init]: should never be used
	partial interface DomHtmlElement {
		[Export ("idName", ArgumentSemantic.Copy)]
		string IdName { get; set;  }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set;  }

		[Export ("lang", ArgumentSemantic.Copy)]
		string Lang { get; set;  }

		[Export ("dir", ArgumentSemantic.Copy)]
		string Dir { get; set;  }

		[Export ("tabIndex")]
		int TabIndex { get; set; } /* int, not NSInteger */

		[Export ("innerHTML", ArgumentSemantic.Copy)]
		string InnerHTML { get; set;  }

		[Export ("innerText", ArgumentSemantic.Copy)]
		string InnerText { get; set;  }

		[Export ("outerHTML", ArgumentSemantic.Copy)]
		string OuterHTML { get; set;  }

		[Export ("outerText", ArgumentSemantic.Copy)]
		string OuterText { get; set;  }

		[Export ("children", ArgumentSemantic.Retain)]
		DomHtmlCollection Children { get;  }

		[Export ("contentEditable", ArgumentSemantic.Copy)]
		string ContentEditable { get; set;  }

		[Export ("isContentEditable")]
		bool IsContentEditable { get;  }

		[Export ("titleDisplayString", ArgumentSemantic.Copy)]
		string TitleDisplayString { get;  }
	}

	//////////////////////////////////////////////////////////////////

	[BaseType (typeof (NSObject))]
	partial interface WebArchive : NSCoding, NSCopying {
		[Export ("initWithMainResource:subresources:subframeArchives:")]
		IntPtr Constructor (WebResource mainResource, NSArray subresources, NSArray subframeArchives);

		[Export ("initWithData:")]
		IntPtr Constructor (NSData data);

		[Export ("mainResource")]
		WebResource MainResource { get; }

		[Export ("subresources")]
		WebResource [] Subresources { get; }

		[Export ("subframeArchives")]
		WebArchive [] SubframeArchives { get; }

		[Export ("data")]
		NSData Data { get; }
	}

	[BaseType (typeof (NSObject))]
	partial interface WebBackForwardList {
		[Export ("addItem:")]
		void AddItem (WebHistoryItem item);

		[Export ("goBack")]
		void GoBack ();

		[Export ("goForward")]
		void GoForward ();

		[Export ("goToItem:")]
		void GoToItem (WebHistoryItem item);

		[Export ("backItem")]
		WebHistoryItem BackItem ();

		[Export ("currentItem")]
		WebHistoryItem CurrentItem ();

		[Export ("forwardItem")]
		WebHistoryItem ForwardItem ();

		[Export ("backListWithLimit:")]
		WebHistoryItem [] BackListWithLimit (int /* int, not NSInteger */ limit);

		[Export ("forwardListWithLimit:")]
		WebHistoryItem [] ForwardListWithLimit (int /* int, not NSInteger */ limit);

		[Export ("backListCount")]
		int BackListCount { get; } /* int, not NSInteger */ 

		[Export ("forwardListCount")]
		int ForwardListCount { get; } /* int, not NSInteger */ 

		[Export ("containsItem:")]
		bool ContainsItem (WebHistoryItem item);

		[Export ("itemAtIndex:")]
		WebHistoryItem ItemAtIndex (int /* int, not NSInteger */ index);

		//Detected properties
		[Export ("capacity")]
		int Capacity { get; set; } /* int, not NSInteger */ 
	}

	[BaseType (typeof (NSObject))]
	partial interface WebDataSource {
		[Export ("initWithRequest:")]
		IntPtr Constructor (NSUrlRequest request);

		[Export ("data")]
		NSData Data { get; }

		[Export ("representation")]
		[Protocolize]
		WebDocumentRepresentation Representation { get; }

		[Export ("webFrame")]
		WebFrame WebFrame { get; }

		[Export ("initialRequest")]
		NSUrlRequest InitialRequest { get; }

		[Export ("request")]
		NSMutableUrlRequest Request { get; }

		[Export ("response")]
		NSUrlResponse Response { get; }

		[Export ("textEncodingName")]
		string TextEncodingName { get; }

		[Export ("isLoading")]
		bool IsLoading { get; }

		[Export ("pageTitle")]
		string PageTitle { get; }

		[Export ("unreachableURL")]
		NSUrl UnreachableURL { get; }

		[Export ("webArchive")]
		WebArchive WebArchive { get; }

		[Export ("mainResource")]
		WebResource MainResource { get; }

		[Export ("subresources")]
		WebResource [] Subresources { get; }

		[Export ("subresourceForURL:")]
		WebResource SubresourceForUrl (NSUrl url);

		[Export ("addSubresource:")]
		void AddSubresource (WebResource subresource);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface WebDocumentRepresentation {
		[Abstract]
		[Export ("setDataSource:")]
		void SetDataSource (WebDataSource dataSource);

		[Abstract]
		[Export ("receivedData:withDataSource:")]
		void ReceivedData (NSData data, WebDataSource dataSource);

		[Abstract]
		[Export ("receivedError:withDataSource:")]
		void ReceivedError (NSError error, WebDataSource dataSource);

		[Abstract]
		[Export ("finishedLoadingWithDataSource:")]
		void FinishedLoading (WebDataSource dataSource);

		[Abstract]
		[Export ("canProvideDocumentSource")]
		bool CanProvideDocumentSource { get; }

		[Abstract]
		[Export ("documentSource")]
		string DocumentSource { get; }

		[Abstract]
		[Export ("title")]
		string Title { get; }
	}

	//
	// This is a protocol that is adopted, in some internal classes
	// this is a problem, so I am hiding it for now
	//
	
//	[BaseType (typeof (NSObject))]
//	[Model]
//	partial interface WebDocumentView {
//		[Abstract]
//		[Export ("setDataSource:")]
//		void SetDataSource (WebDataSource dataSource);
//
//		[Abstract]
//		[Export ("dataSourceUpdated:")]
//		void DataSourceUpdated (WebDataSource dataSource);
//
//		[Abstract]
//		[Export ("setNeedsLayout:")]
//		void SetNeedsLayout (bool flag);
//
//		[Abstract]
//		[Export ("layout")]
//		void Layout ();
//
//		[Abstract]
//		[Export ("viewWillMoveToHostWindow:")]
//		void ViewWillMoveToHostWindow (NSWindow hostWindow);
//
//		[Abstract]
//		[Export ("viewDidMoveToHostWindow")]
//		void ViewDidMoveToHostWindow ();
//	}

	
	[BaseType (typeof (NSUrlDownload))]
	partial interface WebDownload {
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol (FormalSince = "10.11")]
	partial interface WebDownloadDelegate {
		[Export ("downloadWindowForAuthenticationSheet:"), DelegateName ("WebDownloadRequest"), DefaultValue (null)]
		NSWindow OnDownloadWindowForSheet (WebDownload download);
	}
	
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // invalid handle returned
	partial interface WebFrame {
		[Export ("initWithName:webFrameView:webView:")]
		IntPtr Constructor (string name, WebFrameView view, WebView webView);

		[Export ("name")]
		string Name { get; }

		[Export ("webView")]
		WebView WebView { get; }

		[Export ("frameView")]
		WebFrameView FrameView { get; }

		[Export ("DOMDocument")]
		DomDocument DomDocument { get; }

		[Export ("frameElement")]
		DomHtmlElement FrameElement { get; }

		[Export ("loadRequest:")]
		void LoadRequest (NSUrlRequest request);

		[Export ("loadData:MIMEType:textEncodingName:baseURL:")]
		void LoadData (NSData data, string mimeType, string textDncodingName, NSUrl baseUrl);

		[Export ("loadHTMLString:baseURL:")]
		void LoadHtmlString (NSString htmlString, [NullAllowed] NSUrl baseUrl);

		[Export ("loadAlternateHTMLString:baseURL:forUnreachableURL:")]
		void LoadAlternateHtmlString (string htmlString, NSUrl baseURL, NSUrl forUnreachableURL);

		[Export ("loadArchive:")]
		void LoadArchive (WebArchive archive);

		[Export ("dataSource")]
		WebDataSource DataSource { get; }

		[Export ("provisionalDataSource")]
		WebDataSource ProvisionalDataSource { get; }

		[Export ("stopLoading")]
		void StopLoading ();

		[Export ("reload")]
		void Reload ();

		[Export ("reloadFromOrigin")]
		void ReloadFromOrigin ();

		[Export ("findFrameNamed:")]
		WebFrame FindFrameNamed (string name);

		[Export ("parentFrame")]
		WebFrame ParentFrame { get; }

		[Export ("childFrames")]
		WebFrame [] ChildFrames { get; }

		[Export ("windowObject")]
		WebScriptObject WindowObject { get; }

		[Export ("globalContext")]
		/* JSGlobalContextRef */ IntPtr GlobalContext { get; }

#if XAMCORE_2_0
		[Mac (10,10, onlyOn64 : true)]
                [Export ("javaScriptContext", ArgumentSemantic.Strong)]
                JSContext JavaScriptContext { get; }
#endif
	}

	[Model]
	[Protocol (FormalSince = "10.11")]
	[BaseType (typeof (NSObject))]
	partial interface WebFrameLoadDelegate {
		[Export ("webView:didStartProvisionalLoadForFrame:"), EventArgs ("WebFrame")]
		void StartedProvisionalLoad (WebView sender, WebFrame forFrame);

		[Export ("webView:didReceiveServerRedirectForProvisionalLoadForFrame:"), EventArgs ("WebFrame")]
		void ReceivedServerRedirectForProvisionalLoad (WebView sender, WebFrame forFrame);

		[Export ("webView:didFailProvisionalLoadWithError:forFrame:"), EventArgs ("WebFrameError")]
		void FailedProvisionalLoad (WebView sender, NSError error, WebFrame forFrame);

		[Export ("webView:didCommitLoadForFrame:"), EventArgs ("WebFrame")]
		void CommitedLoad (WebView sender, WebFrame forFrame);

		[Export ("webView:didReceiveTitle:forFrame:"), EventArgs ("WebFrameTitle")]
		void ReceivedTitle (WebView sender, string title, WebFrame forFrame);

		[Export ("webView:didReceiveIcon:forFrame:"), EventArgs ("WebFrameImage")]
		void ReceivedIcon (WebView sender, NSImage image, WebFrame forFrame);

		[Export ("webView:didFinishLoadForFrame:"), EventArgs ("WebFrame")]
		void FinishedLoad (WebView sender, WebFrame forFrame);

		[Export ("webView:didFailLoadWithError:forFrame:"), EventArgs ("WebFrameError")]
		void FailedLoadWithError (WebView sender, NSError error, WebFrame forFrame);

		[Export ("webView:didChangeLocationWithinPageForFrame:"), EventArgs ("WebFrame")]
		void ChangedLocationWithinPage (WebView sender, WebFrame forFrame);

		[Export ("webView:willPerformClientRedirectToURL:delay:fireDate:forFrame:"), EventArgs ("WebFrameClientRedirect")]
		void WillPerformClientRedirect (WebView sender, NSUrl toUrl, double secondsDelay, NSDate fireDate, WebFrame forFrame);

		[Export ("webView:didCancelClientRedirectForFrame:"), EventArgs ("WebFrame")]
		void CanceledClientRedirect (WebView sender, WebFrame forFrame);

		[Export ("webView:willCloseFrame:"), EventArgs ("WebFrame")]
		void WillCloseFrame (WebView sender, WebFrame forFrame);

		[Export ("webView:didClearWindowObject:forFrame:"), EventArgs ("WebFrameScriptFrame")]
		void ClearedWindowObject (WebView webView, WebScriptObject windowObject, WebFrame forFrame);

		[Export ("webView:windowScriptObjectAvailable:"), EventArgs ("WebFrameScriptObject")]
		void WindowScriptObjectAvailable (WebView webView, WebScriptObject windowScriptObject);

#if XAMCORE_2_0
                [Export ("webView:didCreateJavaScriptContext:forFrame:"), EventArgs ("WebFrameJavaScriptContext")]
                void DidCreateJavaScriptContext (WebView webView, JSContext context, WebFrame frame);
#endif
	}

	[BaseType (typeof (NSView))]
	partial interface WebFrameView {
		[Export ("webFrame")]
		WebFrame WebFrame { get; }

		// This is an NSVIew<WebDocumentView>, so we need to figure what to do about that
		[Export ("documentView")]
		NSView DocumentView { get; }

		[Export ("canPrintHeadersAndFooters")]
		bool CanPrintHeadersAndFooters { get; }

		[Export ("printOperationWithPrintInfo:")]
		NSPrintOperation GetPrintOperation (NSPrintInfo printInfo);

		[Export ("documentViewShouldHandlePrint")]
		bool DocumentViewShouldHandlePrint { get; }

		[Export ("printDocumentView")]
		void PrintDocumentView ();

		//Detected properties
		[Export ("allowsScrolling")]
		bool AllowsScrolling { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface WebHistory {
		[Export ("orderedLastVisitedDays")]
		NSCalendarDate [] OrderedLastVisitedDays { get; }

		[Export ("historyItemLimit")]
		int HistoryItemLimit { get; set; } /* int, not NSInteger */

		[Export ("historyAgeInDaysLimit")]
		int HistoryAgeInDaysLimit { get; set; } /* int, not NSInteger */

		[Static, Export ("optionalSharedHistory")]
		WebHistory OptionalSharedHistory { get; }

		[Static, Export ("setOptionalSharedHistory:")]
		void SetOptionalSharedHistory ([NullAllowed] WebHistory history);

		[Export ("loadFromURL:error:")]
		bool Load (NSUrl url, out NSError error);

		[Export ("saveToURL:error:")]
		bool Save (NSUrl url, out NSError error);

		[Export ("addItems:")]
		void AddItems (WebHistoryItem [] newItems);

		[Export ("removeItems:")]
		void RemoveItems (WebHistoryItem [] items);

		[Export ("removeAllItems")]
		void RemoveAllItems ();

		[Export ("orderedItemsLastVisitedOnDay:")]
		WebHistoryItem [] GetOrderedItemsLastVisitedOnDay (NSCalendarDate calendarDate);

		[Export ("itemForURL:")]
		WebHistoryItem GetHistoryItemForUrl (NSUrl url);
	}
	
	[BaseType (typeof (NSObject))]
	partial interface WebHistoryItem : NSCopying {
		[Export ("initWithURLString:title:lastVisitedTimeInterval:")]
		IntPtr Constructor (string urlString, string title, double lastVisitedTimeInterval);

		[Export ("originalURLString")]
		string OriginalUrlString { get; }

		[Export ("URLString")]
		string UrlString { get; }

		[Export ("title")]
		string Title { get; }

		[Export ("lastVisitedTimeInterval")]
		double LastVisitedTimeInterval { get; }

		[Export ("icon")]
		NSImage Icon { get; }

		//Detected properties
		[Export ("alternateTitle")]
		string AlternateTitle { get; set; }

		[Field ("WebHistoryItemChangedNotification")]
		[Notification]
		NSString ChangedNotification { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface WebOpenPanelResultListener {
		[Export ("chooseFilename:")]
		void ChooseFilename (string filename);

		[Export ("chooseFilenames:")]
		void ChooseFilenames (string [] filenames);

		[Export ("cancel")]
		void Cancel ();
	}

	interface IWebOpenPanelResultListener {}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol (FormalSince = "10.11")]
	partial interface WebPolicyDelegate  {
		[Export ("webView:decidePolicyForNavigationAction:request:frame:decisionListener:"), EventArgs ("WebNavigationPolicy")]
		void DecidePolicyForNavigation (WebView webView, NSDictionary actionInformation, NSUrlRequest request, WebFrame frame, NSObject decisionToken);

		[Export ("webView:decidePolicyForNewWindowAction:request:newFrameName:decisionListener:"), EventArgs ("WebNewWindowPolicy")]
		void DecidePolicyForNewWindow (WebView webView, NSDictionary actionInformation, NSUrlRequest request, string newFrameName, NSObject decisionToken);

		[Export ("webView:decidePolicyForMIMEType:request:frame:decisionListener:"), EventArgs ("WebMimeTypePolicy")]
		void DecidePolicyForMimeType (WebView webView, string mimeType, NSUrlRequest request, WebFrame frame, NSObject decisionToken);

		[Export ("webView:unableToImplementPolicyWithError:frame:"), EventArgs ("WebFailureToImplementPolicy")]
		void UnableToImplementPolicy (WebView webView, NSError error, WebFrame frame);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface WebPolicyDecisionListener {
		[Export ("use")]
		void Use ();

		[Export ("download")]
		void Download ();

		[Export ("ignore")]
		void Ignore ();
	}
	
	[BaseType (typeof (NSObject))]
	partial interface WebPreferences : NSCoding {
		[Static]
		[Export ("standardPreferences")]
		WebPreferences StandardPreferences { get; }

		[Export ("initWithIdentifier:")]
		IntPtr Constructor (string identifier);

		[Export ("identifier")]
		string Identifier { get; }

		[Export ("arePlugInsEnabled")]
		bool PlugInsEnabled { get; [Bind ("setPlugInsEnabled:")] set; }

		//Detected properties
		[Export ("standardFontFamily")]
		string StandardFontFamily { get; set; }

		[Export ("fixedFontFamily")]
		string FixedFontFamily { get; set; }

		[Export ("serifFontFamily")]
		string SerifFontFamily { get; set; }

		[Export ("sansSerifFontFamily")]
		string SansSerifFontFamily { get; set; }

		[Export ("cursiveFontFamily")]
		string CursiveFontFamily { get; set; }

		[Export ("fantasyFontFamily")]
		string FantasyFontFamily { get; set; }

		[Export ("defaultFontSize")]
		int DefaultFontSize { get; set; } /* int, not NSInteger */

		[Export ("defaultFixedFontSize")]
		int DefaultFixedFontSize { get; set; } /* int, not NSInteger */

		[Export ("minimumFontSize")]
		int MinimumFontSize { get; set; } /* int, not NSInteger */

		[Export ("minimumLogicalFontSize")]
		int MinimumLogicalFontSize { get; set; } /* int, not NSInteger */

		[Export ("defaultTextEncodingName")]
		string DefaultTextEncodingName { get; set; }

		[Export ("userStyleSheetEnabled")]
		bool UserStyleSheetEnabled { get; set; }

		[Export ("userStyleSheetLocation", ArgumentSemantic.Retain)]
		NSUrl UserStyleSheetLocation { get; set; }

		[Export ("javaEnabled")]
		bool JavaEnabled { [Bind ("isJavaEnabled")]get; set; }

		[Export ("javaScriptEnabled")]
		bool JavaScriptEnabled { [Bind ("isJavaScriptEnabled")]get; set; }

		[Export ("javaScriptCanOpenWindowsAutomatically")]
		bool JavaScriptCanOpenWindowsAutomatically { get; set; }

		[Export ("allowsAnimatedImages")]
		bool AllowsAnimatedImages { get; set; }

		[Export ("allowsAnimatedImageLooping")]
		bool AllowsAnimatedImageLooping { get; set; }

		[Export ("loadsImagesAutomatically")]
		bool LoadsImagesAutomatically { get; set; }

		[Export ("autosaves")]
		bool Autosaves { get; set; }

		[Export ("shouldPrintBackgrounds")]
		bool ShouldPrintBackgrounds { get; set; }

		[Export ("privateBrowsingEnabled")]
		bool PrivateBrowsingEnabled { get; set; }

		[Export ("tabsToLinks")]
		bool TabsToLinks { get; set; }

		[Export ("usesPageCache")]
		bool UsesPageCache { get; set; }

		[Export ("cacheModel")]
		WebCacheModel CacheModel { get; set; }
	}

	[BaseType (typeof (NSObject))]
	partial interface WebResource : NSCoding, NSCopying {
		[Export ("initWithData:URL:MIMEType:textEncodingName:frameName:")]
		IntPtr Constructor (NSData data, NSUrl url, string mimeType, string textEncodingName, string frameName);

		[Export ("data")]
		NSData Data { get; }

		[Export ("URL")]
		NSUrl Url { get; }

		[Export ("MIMEType")]
		string MimeType { get; }

		[Export ("textEncodingName")]
		string TextEncodingName { get; }

		[Export ("frameName")]
		string FrameName { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol (FormalSince = "10.11")]
	partial interface WebResourceLoadDelegate {
		[Export ("webView:identifierForInitialRequest:fromDataSource:"), DelegateName ("WebResourceIdentifierRequest"), DefaultValue (null)]
		NSObject OnIdentifierForInitialRequest (WebView sender, NSUrlRequest request, WebDataSource dataSource);

		[Export ("webView:resource:willSendRequest:redirectResponse:fromDataSource:"), DelegateName ("WebResourceOnRequestSend"), DefaultValueFromArgument ("request")]
		NSUrlRequest OnSendRequest (WebView sender, NSObject identifier, NSUrlRequest request, NSUrlResponse redirectResponse, WebDataSource dataSource);

		[Export ("webView:resource:didReceiveAuthenticationChallenge:fromDataSource:"), EventArgs ("WebResourceAuthenticationChallenge")]
		void OnReceivedAuthenticationChallenge (WebView sender, NSObject identifier, NSUrlAuthenticationChallenge challenge, WebDataSource dataSource);

		[Export ("webView:resource:didCancelAuthenticationChallenge:fromDataSource:"), EventArgs ("WebResourceCancelledChallenge")]
		void OnCancelledAuthenticationChallenge (WebView sender, NSObject identifier, NSUrlAuthenticationChallenge challenge, WebDataSource dataSource);

		[Export ("webView:resource:didReceiveResponse:fromDataSource:"), EventArgs ("WebResourceReceivedResponse")]
		void OnReceivedResponse (WebView sender, NSObject identifier, NSUrlResponse responseReceived, WebDataSource dataSource);

		[Export ("webView:resource:didReceiveContentLength:fromDataSource:"), EventArgs ("WebResourceReceivedContentLength")]
		void OnReceivedContentLength (WebView sender, NSObject identifier, nint length, WebDataSource dataSource);

		[Export ("webView:resource:didFinishLoadingFromDataSource:"), EventArgs ("WebResourceCompleted")]
		void OnFinishedLoading (WebView sender, NSObject identifier, WebDataSource dataSource);

		[Export ("webView:resource:didFailLoadingWithError:fromDataSource:"), EventArgs ("WebResourceError")]
		void OnFailedLoading (WebView sender, NSObject identifier, NSError withError, WebDataSource dataSource);

		[Export ("webView:plugInFailedWithError:dataSource:"), EventArgs ("WebResourcePluginError")]
		void OnPlugInFailed (WebView sender, NSError error, WebDataSource dataSource);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol (FormalSince = "10.11")]
	partial interface WebUIDelegate {
		[Export ("webView:createWebViewWithRequest:"), DelegateName("CreateWebViewFromRequest"), DefaultValue (null)]
		WebView UICreateWebView (WebView sender, NSUrlRequest request);

		[Export ("webViewShow:")]
		void UIShow (WebView sender);

		[Export ("webView:createWebViewModalDialogWithRequest:"), DelegateName ("WebViewCreate"), DefaultValue (null)]
		WebView UICreateModalDialog (WebView sender, NSUrlRequest request);

		[Export ("webViewRunModal:")]
		void UIRunModal (WebView sender);

		[Export ("webViewClose:")]
		void UIClose (WebView sender);

		[Export ("webViewFocus:")]
		void UIFocus (WebView sender);

		[Export ("webViewUnfocus:")]
		void UIUnfocus (WebView sender);
 
		[Export ("webViewFirstResponder:"), DelegateName ("WebViewGetResponder"), DefaultValue (null)]
		NSResponder UIGetFirstResponder (WebView sender);

		[Export ("webView:makeFirstResponder:"), EventArgs("WebViewResponder")]
		void UIMakeFirstResponder (WebView sender, NSResponder newResponder);

		[Export ("webView:setStatusText:"), EventArgs("WebViewStatusText")]
		void UISetStatusText (WebView sender, string text);
 
		[Export ("webViewStatusText:"), DelegateName ("WebViewGetString"), DefaultValue (null)]
		string UIGetStatusText (WebView sender);

		[Export ("webViewAreToolbarsVisible:"), DelegateName ("WebViewGetBool"), DefaultValue (null)]
		bool UIAreToolbarsVisible (WebView sender);

		[Export ("webView:setToolbarsVisible:"), EventArgs("WebViewToolBars")]
		void UISetToolbarsVisible (WebView sender, bool visible);

		[Export ("webViewIsStatusBarVisible:"), DelegateName ("WebViewGetBool"), DefaultValue (false)]
		bool UIIsStatusBarVisible (WebView sender);

		[Export ("webView:setStatusBarVisible:"), EventArgs("WebViewStatusBar")]
		void UISetStatusBarVisible (WebView sender, bool visible);

		[Export ("webViewIsResizable:"), DelegateName("WebViewGetBool"), DefaultValue (null)]
		bool UIIsResizable (WebView sender);

		[Export ("webView:setResizable:"), EventArgs("WebViewResizable")]
		void UISetResizable (WebView sender, bool resizable);

		[Export ("webView:setFrame:"), EventArgs("WebViewFrame")]
		void UISetFrame (WebView sender, CGRect newFrame);

		[Export ("webViewFrame:"), DelegateName("WebViewGetRectangle"), DefaultValue (null)]
		CGRect UIGetFrame (WebView sender);

		[Export ("webView:runJavaScriptAlertPanelWithMessage:initiatedByFrame:"), EventArgs("WebViewJavaScriptFrame")]
		void UIRunJavaScriptAlertPanelMessage (WebView sender, string withMessage, WebFrame initiatedByFrame);

		[Export ("webView:runJavaScriptConfirmPanelWithMessage:initiatedByFrame:"), DelegateName("WebViewConfirmationPanel"), DefaultValue (null)]
		bool UIRunJavaScriptConfirmationPanel (WebView sender, string withMessage, WebFrame initiatedByFrame);

		[Export ("webView:runJavaScriptTextInputPanelWithPrompt:defaultText:initiatedByFrame:"), DelegateName ("WebViewPromptPanel"), DefaultValue (null)]
		string UIRunJavaScriptTextInputPanelWithFrame (WebView sender, string prompt, string defaultText, WebFrame initiatedByFrame);

		[Export ("webView:runBeforeUnloadConfirmPanelWithMessage:initiatedByFrame:"), DelegateName("WebViewJavaScriptFrame"), DefaultValue (null)]
		bool UIRunBeforeUnload (WebView sender, string message, WebFrame initiatedByFrame);

		[Export ("webView:runOpenPanelForFileButtonWithResultListener:"), EventArgs ("WebViewRunOpenPanel")]
#if XAMCORE_2_0
		void UIRunOpenPanelForFileButton (WebView sender, IWebOpenPanelResultListener resultListener);
#else
		void UIRunOpenPanelForFileButton (WebView sender, WebOpenPanelResultListener resultListener);
#endif

		[Export ("webView:mouseDidMoveOverElement:modifierFlags:"), EventArgs ("WebViewMouseMoved")]
		void UIMouseDidMoveOverElement (WebView sender, NSDictionary elementInformation, NSEventModifierMask modifierFlags);

		[Export ("webView:contextMenuItemsForElement:defaultMenuItems:"), DelegateName("WebViewGetContextMenuItems"), DefaultValue (null)]
		NSMenuItem [] UIGetContextMenuItems (WebView sender, NSDictionary forElement, NSMenuItem [] defaultMenuItems);
		
		[Export ("webView:validateUserInterfaceItem:defaultValidation:"), DelegateName ("WebViewValidateUserInterface"), DefaultValueFromArgument ("defaultValidation")]
		bool UIValidateUserInterfaceItem (WebView webView, NSObject validatedUserInterfaceItem, bool defaultValidation);

		[Export ("webView:shouldPerformAction:fromSender:"), DelegateName("WebViewPerformAction"), DefaultValue (null)]
		bool UIShouldPerformActionfromSender (WebView webView, Selector action, NSObject sender);

		[Export ("webView:dragDestinationActionMaskForDraggingInfo:"), DelegateName ("DragDestinationGetActionMask"), DefaultValue (0)]
		NSEventModifierMask UIGetDragDestinationActionMask (WebView webView, NSDraggingInfo draggingInfo);

		[Export ("webView:willPerformDragDestinationAction:forDraggingInfo:"), EventArgs ("WebViewDrag")]
		void UIWillPerformDragDestination (WebView webView, WebDragDestinationAction action, NSDraggingInfo draggingInfo);

		[Export ("webView:dragSourceActionMaskForPoint:"), DelegateName ("DragSourceGetActionMask"), DefaultValue (0)]
		NSEventModifierMask UIDragSourceActionMask (WebView webView, CGPoint point);

		[Export ("webView:willPerformDragSourceAction:fromPoint:withPasteboard:"), EventArgs ("WebViewPerformDrag")]
		void UIWillPerformDragSource (WebView webView, WebDragSourceAction action, CGPoint sourcePoint, NSPasteboard pasteboard);

		[Export ("webView:printFrameView:"), EventArgs("WebViewPrint")]
		void UIPrintFrameView (WebView sender, WebFrameView frameView);

		[Export ("webViewHeaderHeight:"), DelegateName("WebViewGetFloat"), DefaultValue (null)]
		float UIGetHeaderHeight (WebView sender); /* float, not CGFloat */

		[Export ("webViewFooterHeight:"), DelegateName("WebViewGetFloat"), DefaultValue (null)]
		float UIGetFooterHeight (WebView sender); /* float, not CGFloat */

		[Export ("webView:drawHeaderInRect:"), EventArgs ("WebViewHeader")]
		void UIDrawHeaderInRect (WebView sender, CGRect rect);

		[Export ("webView:drawFooterInRect:"), EventArgs ("WebViewFooter")]
		void UIDrawFooterInRect (WebView sender, CGRect rect);

		[Export ("webView:runJavaScriptAlertPanelWithMessage:"), EventArgs("WebViewJavaScript")]
		void UIRunJavaScriptAlertPanel (WebView sender, string message);

		[Export ("webView:runJavaScriptConfirmPanelWithMessage:"), DelegateName("WebViewPrompt"), DefaultValue (null)]
		bool UIRunJavaScriptConfirmPanel (WebView sender, string message);

		[Export ("webView:runJavaScriptTextInputPanelWithPrompt:defaultText:"), DelegateName("WebViewJavaScriptInput"), DefaultValue (null)]
		string UIRunJavaScriptTextInputPanel (WebView sender, string prompt, string defaultText);

		[Export ("webView:setContentRect:"), EventArgs("WebViewContent")]
		void UISetContentRect (WebView sender, CGRect frame);

		[Export ("webViewContentRect:"), DelegateName("WebViewGetRectangle"), DefaultValue (null)]
		CGRect UIGetContentRect (WebView sender);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // crash on dispose, documented as "You can not create a WebScriptObject object directly."
	partial interface WebScriptObject {
		[Static, Export ("throwException:")]
		bool ThrowException (string exceptionMessage);

		[Export ("JSObject")]
		/* JSObjectRef */ IntPtr JSObject { get; }

		[Export ("callWebScriptMethod:withArguments:")]
		NSObject CallWebScriptMethod (string name, NSObject [] arguments);

		[Export ("evaluateWebScript:")]
		NSObject EvaluateWebScript (string script);

		[Export ("removeWebScriptKey:")]
		void RemoveWebScriptKey (string name);

		[Export ("stringRepresentation")]
		string StringRepresentation { get; }

		[Export ("webScriptValueAtIndex:")]
		NSObject WebScriptValueAtIndex (int /* unsigned int */ index);

		[Export ("setWebScriptValueAtIndex:value:")]
#if XAMCORE_2_0
		void SetWebScriptValueAtIndex (int /* unsigned int */ index, NSObject value);
#else
		[Obsolete ("Use 'SetWebScriptValueAtIndex' instead.")]
		void SetWebScriptValueAtIndexvalue (int /* unsigned int */ index, NSObject value);
#endif

		[Export ("setException:")]
		void SetException (string description);

#if XAMCORE_2_0
		[Mac (10,10, onlyOn64 : true)]
                [Export ("JSValue")]
                JSValue JSValue { get; }
#endif
	}

	[BaseType (typeof (NSView),
		   Events=new Type [] {
			   typeof (WebFrameLoadDelegate),
			   typeof (WebDownloadDelegate),
			   typeof (WebResourceLoadDelegate),
			   typeof (WebUIDelegate),
			   typeof (WebPolicyDelegate) },
		   Delegates=new string [] {
			   "WeakFrameLoadDelegate",
			   "WeakDownloadDelegate",
			   "WeakResourceLoadDelegate",
			   "WeakUIDelegate",
			   "WeakPolicyDelegate" }
		   )]
	partial interface WebView {
		[Static]
		[Export ("canShowMIMEType:")]
		bool CanShowMimeType (string MimeType);

		[Static]
		[Export ("canShowMIMETypeAsHTML:")]
		bool CanShowMimeTypeAsHtml (string mimeType);

		[Static]
		[Export ("MIMETypesShownAsHTML")]
		string [] MimeTypesShownAsHtml { get; set; }

		[Static]
		[Export ("URLFromPasteboard:")]
		NSUrl UrlFromPasteboard (NSPasteboard pasteboard);

		[Static]
		[Export ("URLTitleFromPasteboard:")]
		string UrlTitleFromPasteboard (NSPasteboard pasteboard);

		[Static]
		[Export ("registerURLSchemeAsLocal:")]
		void RegisterUrlSchemeAsLocal (string scheme);

		[Export ("initWithFrame:frameName:groupName:")]
		IntPtr Constructor (CGRect frame, [NullAllowed] string frameName, [NullAllowed]string groupName);

		[Export ("close")]
		void Close ();

		[Export ("mainFrame")]
		WebFrame MainFrame { get; }

		[Export ("selectedFrame")]
		WebFrame SelectedFrame { get; }

		[Export ("backForwardList")]
		WebBackForwardList BackForwardList { get; } 

		[Export ("setMaintainsBackForwardList:")]
		void SetMaintainsBackForwardList (bool flag);

		[Export ("goBack")]
		bool GoBack ();

		[Export ("goForward")]
		bool GoForward ();

		[Export ("goToBackForwardItem:")]
		bool GoToBackForwardItem (WebHistoryItem item);

		[Export ("userAgentForURL:")]
		string UserAgentForUrl (NSUrl url);

		[Export ("supportsTextEncoding")]
		bool SupportsTextEncoding { get; }

		[Export ("stringByEvaluatingJavaScriptFromString:")]
		string StringByEvaluatingJavaScriptFromString (string script);

		[Export ("windowScriptObject")]
		WebScriptObject WindowScriptObject { get; }

		[Export ("searchFor:direction:caseSensitive:wrap:")]
		bool Search (string forString, bool forward, bool caseSensitive, bool wrap);

		[Static]
		[Export ("registerViewClass:representationClass:forMIMEType:")]
		void RegisterViewClass (Class viewClass, Class representationClass, string mimeType);

		[Export ("estimatedProgress")]
		double EstimatedProgress { get; }

		[Export ("isLoading")]
		bool IsLoading { get; }

		[Export ("elementAtPoint:")]
		NSDictionary ElementAtPoint (CGPoint point);

		[Export ("pasteboardTypesForSelection")]
		NSPasteboard [] PasteboardTypesForSelection { get; }

		[Export ("writeSelectionWithPasteboardTypes:toPasteboard:")]
		void WriteSelection (NSObject [] types, NSPasteboard pasteboard);

		[Export ("pasteboardTypesForElement:")]
		NSObject [] PasteboardTypesForElement (NSDictionary element);

		[Export ("writeElement:withPasteboardTypes:toPasteboard:")]
		void WriteElement (NSDictionary element, NSObject [] pasteboardTypes, NSPasteboard toPasteboard);

		[Export ("moveDragCaretToPoint:")]
		void MoveDragCaretToPoint (CGPoint point);

		[Export ("removeDragCaret")]
		void RemoveDragCaret ();

		[Export ("mainFrameDocument")]
		DomDocument MainFrameDocument { get; }

		[Export ("mainFrameTitle")]
		string MainFrameTitle { get; }

		[Export ("mainFrameIcon")]
		NSImage MainFrameIcon { get; }

		//Detected properties
		[Export ("shouldCloseWithWindow")]
		bool ShouldCloseWithWindow { get; set; }

		[Export ("resourceLoadDelegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakResourceLoadDelegate { get; set; }

		[Wrap ("WeakResourceLoadDelegate")]
		[Protocolize]
		WebResourceLoadDelegate ResourceLoadDelegate { get; set; }

		[Export ("downloadDelegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDownloadDelegate { get; set; }

		[Wrap ("WeakDownloadDelegate")]
		[Protocolize]
		WebDownloadDelegate DownloadDelegate { get; set; }

		[Export ("frameLoadDelegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakFrameLoadDelegate { get; set; }

		[Wrap ("WeakFrameLoadDelegate")]
		[Protocolize]
		WebFrameLoadDelegate FrameLoadDelegate { get; set; }

		[Export ("UIDelegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakUIDelegate { get; set; }

		[Wrap ("WeakUIDelegate")]
		[Protocolize]
		WebUIDelegate UIDelegate { get; set; }

		[Export ("policyDelegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakPolicyDelegate { get; set; }

		[Wrap ("WeakPolicyDelegate")]
		[Protocolize]
		WebPolicyDelegate PolicyDelegate { get; set; }
		
		[Export ("textSizeMultiplier")]
		float TextSizeMultiplier { get; set; } /* float, not CGFloat */

		[Export ("applicationNameForUserAgent")]
		string ApplicationNameForUserAgent { get; set; }

		[Export ("customUserAgent")]
		string CustomUserAgent { get; set; }

		[Export ("customTextEncodingName")]
		string CustomTextEncodingName { get; set; }

		[Export ("mediaStyle")]
		string MediaStyle { get; set; }

		[Export ("preferences", ArgumentSemantic.Retain)]
		WebPreferences Preferences { get; set; }

		[Export ("preferencesIdentifier")]
		string PreferencesIdentifier { get; set; }

		[Export ("hostWindow", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSWindow HostWindow { get; set; }

		[Export ("groupName")]
		string GroupName { get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[Export ("shouldUpdateWhileOffscreen")]
		bool UpdateWhileOffscreen { get; set; }

		[Export ("mainFrameURL")]
		string MainFrameUrl { get; set; }

		// NSUserInterfaceValidations
		[Export ("reload:")]
		void Reload (NSObject sender);

		[Export ("reloadFromOrigin:")]
		void ReloadFromOrigin (NSObject sender);

		[Export ("canGoBack")]
		bool CanGoBack ();

		//[Export ("goBack:")]
		//void GoBack (NSObject sender);

		[Export ("canGoForward")]
		bool CanGoForward ();

		//[Export ("goForward:")]
		//void GoForward (NSObject sender);

		[Export ("canMakeTextLarger")]
		bool CanMakeTextLarger ();

		[Export ("makeTextLarger:")]
		void MakeTextLarger (NSObject sender);

		[Export ("canMakeTextSmaller")]
		bool CanMakeTextSmaller ();

		[Export ("makeTextSmaller:")]
		void MakeTextSmaller (NSObject sender);

		[Export ("canMakeTextStandardSize")]
		bool CanMakeTextStandardSize ();

		[Export ("makeTextStandardSize:")]
		void MakeTextStandardSize (NSObject sender);

		[Export ("toggleContinuousSpellChecking:")]
		void ToggleContinuousSpellChecking (NSObject sender);

		[Export ("toggleSmartInsertDelete:")]
		void ToggleSmartInsertDelete (NSObject sender);

		[Export ("setSelectedDOMRange:affinity:")]
		void SetSelectedDomRange (DomRange range, NSSelectionAffinity selectionAffinity);

		[Export ("selectedDOMRange")]
		DomRange SelectedDomRange { get; }

		[Export ("selectionAffinity")]
		NSSelectionAffinity SelectionAffinity { get; }

		[Export ("maintainsInactiveSelection")]
		bool MaintainsInactiveSelection { get; }

		[Export ("spellCheckerDocumentTag")]
		nint SpellCheckerDocumentTag { get; }

		[Export ("undoManager")]
		NSUndoManager UndoManager { get; }

		[Export ("styleDeclarationWithText:")]
		DomCssStyleDeclaration StyleDeclarationWithText (string text);

		//Detected properties
		[Export ("editable")]
		bool Editable { [Bind ("isEditable")]get; set; }

		[Export ("typingStyle")]
		DomCssStyleDeclaration TypingStyle { get; set; }

		[Export ("smartInsertDeleteEnabled")]
		bool SmartInsertDeleteEnabled { get; set; }

		[Export ("continuousSpellCheckingEnabled")]
		bool ContinuousSpellCheckingEnabled { [Bind ("isContinuousSpellCheckingEnabled")]get; set; }

		[Export ("editingDelegate", ArgumentSemantic.Assign)]
		NSObject EditingDelegate { get; set; }

		[Export ("replaceSelectionWithMarkupString:")]
		void ReplaceSelectionWithMarkupString (string markupString);

		[Export ("replaceSelectionWithArchive:")]
		void ReplaceSelectionWithArchive (WebArchive archive);

		[Export ("deleteSelection")]
		void DeleteSelection ();

		[Export ("applyStyle:")]
		void ApplyStyle (DomCssStyleDeclaration style);

		[Export ("cut:")]
		void Cut (NSObject sender);

		[Export ("paste:")]
		void Paste (NSObject sender);

		[Export ("copyFont:")]
		void CopyFont (NSObject sender);

		[Export ("pasteFont:")]
		void PasteFont (NSObject sender);

		[Export ("delete:")]
		void Delete (NSObject sender);

		[Export ("pasteAsPlainText:")]
		void PasteAsPlainText (NSObject sender);

		[Export ("pasteAsRichText:")]
		void PasteAsRichText (NSObject sender);

		[Export ("changeFont:")]
		void ChangeFont (NSObject sender);

		[Export ("changeAttributes:")]
		void ChangeAttributes (NSObject sender);

		[Export ("changeDocumentBackgroundColor:")]
		void ChangeDocumentBackgroundColor (NSObject sender);

		[Export ("changeColor:")]
		void ChangeColor (NSObject sender);

		[Export ("alignCenter:")]
		void AlignCenter (NSObject sender);

		[Export ("alignJustified:")]
		void AlignJustified (NSObject sender);

		[Export ("alignLeft:")]
		void AlignLeft (NSObject sender);

		[Export ("alignRight:")]
		void AlignRight (NSObject sender);

		[Export ("checkSpelling:")]
		void CheckSpelling (NSObject sender);

		[Export ("showGuessPanel:")]
		void ShowGuessPanel (NSObject sender);

		[Export ("performFindPanelAction:")]
		void PerformFindPanelAction (NSObject sender);

		[Export ("startSpeaking:")]
		void StartSpeaking (NSObject sender);

		[Export ("stopSpeaking:")]
		void StopSpeaking (NSObject sender);

		[Export ("moveToBeginningOfSentence:")]
		void MoveToBeginningOfSentence (NSObject sender);

		[Export ("moveToBeginningOfSentenceAndModifySelection:")]
		void MoveToBeginningOfSentenceAndModifySelection (NSObject sender);

		[Export ("moveToEndOfSentence:")]
		void MoveToEndOfSentence (NSObject sender);

		[Export ("moveToEndOfSentenceAndModifySelection:")]
		void MoveToEndOfSentenceAndModifySelection (NSObject sender);

		[Export ("selectSentence:")]
		void SelectSentence (NSObject sender);
	}

	partial interface WebPolicyDelegate {
		
		[Field ("WebActionNavigationTypeKey")]
		NSString WebActionNavigationTypeKey { get; }

		[Field ("WebActionElementKey")]
		NSString WebActionElementKey { get; }

		[Field ("WebActionButtonKey")]
		NSString WebActionButtonKey { get; }

		[Field ("WebActionModifierFlagsKey")]
		NSString WebActionModifierFlagsKey { get; }

		[Field ("WebActionOriginalURLKey")]
		NSString WebActionOriginalUrlKey { get; }
	}

	[BaseType (typeof (DomObject), Name="DOMBlob")]
	[DisableDefaultCtor]
	partial interface DomBlob {
		[Export ("size")]
		ulong Size { get; }
	}

	[BaseType (typeof (DomBlob), Name="DOMFile")]
	[DisableDefaultCtor]
	partial interface DomFile {
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }
	}

	[BaseType (typeof (DomObject), Name="DOMFileList")]
	[DisableDefaultCtor]
	partial interface DomFileList {
		[Export ("length")]
		uint Length { get; } /* unsigned int */

		[Export ("item:")]
		DomFile GetItem (int /* unsigned int */ index);
	}

	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLFormElement")]
	[DisableDefaultCtor]
	partial interface DomHtmlFormElement {
		[Export ("acceptCharset", ArgumentSemantic.Copy)]
		string AcceptCharset { get; set; }

		[Export ("action", ArgumentSemantic.Copy)]
		string Action { get; set; }

		[Export ("enctype", ArgumentSemantic.Copy)]
		string EncodingType { get; set; }

		[Export ("encoding", ArgumentSemantic.Copy)]
		string Encoding { get; set; }

		[Export ("method", ArgumentSemantic.Copy)]
		string Method { get; set; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		[Export ("target", ArgumentSemantic.Copy)]
		string Target { get; set; }

		[Export ("elements", ArgumentSemantic.Retain)]
		DomHtmlCollection Elements { get; }

		[Export ("length")]
		int Length { get; } /* unsigned int */

		[Export ("submit")]
		void Submit ();

		[Export ("reset")]
		void Reset ();
	}

	partial interface DomHtmlTextAreaElement {
		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }
	}

	partial interface DomHtmlInputElement {
		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }

		[Export ("files", ArgumentSemantic.Retain), Mavericks]
		DomFileList Files { get; set; }
	}

		[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLAnchorElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlAnchorElement {

		[Export ("charset")]
		string Charset { get; set; }

		[Export ("coords")]
		string Coords { get; set; }

		[Export ("href")]
		string HRef { get; set; }

		[Export ("hreflang")]
		string HRefLang { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("rel")]
		string Rel { get; set; }

		[Export ("rev")]
		string Rev { get; set; }

		[Export ("shape")]
		string Shape { get; set; }

		[Export ("target")]
		string Target { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Availability (Introduced = Platform.Mac_10_4, Deprecated = Platform.Mac_10_8)]
		[Export ("accessKey")]
		string AccessKey { get; set; }

		[Mac (10,5)]
		[Export ("hashName")]
		string HashName { get; }

		[Mac (10,5)]
		[Export ("host")]
		string Host { get; }

		[Mac (10,5)]
		[Export ("hostname")]
		string Hostname { get; }

		[Mac (10,5)]
		[Export ("pathname")]
		string Pathname { get; }

		[Mac (10,5)]
		[Export ("port")]
		string Port { get; }

		[Mac (10,5)]
		[Export ("protocol")]
		string Protocol { get; }

		[Mac (10,5)]
		[Export ("search")]
		string Search { get; }

		[Mac (10,5)]
		[Export ("text")]
		string Text { get; }

		[Mac (10,5)]
		[Export ("absoluteLinkURL", ArgumentSemantic.Copy)]
		NSUrl AbsoluteImageUrl { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLAppletElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlAppletElement {

		[Export ("align")]
		string Align { get; set; }

		[Export ("alt")]
		string Alt { get; set; }

		[Export ("archive")]
		string Archive { get; set; }

		[Export ("code")]
		string Code { get; set; }

		[Export ("codeBase")]
		string CodeBase { get; set; }

		[Export ("height")]
		string Height { get; set; }

		[Export ("hspace")]
		int HSpace { get; set; } /* int, not NSInteger */

		[Export ("name")]
		string Name { get; set; }

		[Export ("object")]
		string Object { get; set; }

		[Export ("vspace")]
		int VSpace { get; set; } /* int, not NSInteger */

		[Export ("width")]
		string Width { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLAreaElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlAreaElement {

		[Export ("alt")]
		string Alt { get; set; }

		[Export ("coords")]
		string Coords { get; set; }

		[Export ("href")]
		string HRef { get; set; }

		[Export ("noHref")]
		bool NoHRef { get; set; }

		[Export ("shape")]
		string Shape { get; set; }

		[Export ("target")]
		string Target { get; set; }

		[Availability (Introduced = Platform.Mac_10_4, Deprecated = Platform.Mac_10_8)]
		[Export ("accessKey")]
		string AccessKey { get; set; }

		[Mac (10,5)]
		[Export ("hashName")]
		string HashName { get; }

		[Mac (10,5)]
		[Export ("host")]
		string Host { get; }

		[Mac (10,5)]
		[Export ("hostname")]
		string Hostname { get; }

		[Mac (10,5)]
		[Export ("pathname")]
		string Pathname { get; }

		[Mac (10,5)]
		[Export ("port")]
		string Port { get; }

		[Mac (10,5)]
		[Export ("protocol")]
		string Protocol { get; }

		[Mac (10,5)]
		[Export ("search")]
		string Search { get; }

		[Mac (10,5)]
		[Export ("absoluteLinkURL", ArgumentSemantic.Copy)]
		NSUrl AbsoluteImageUrl { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLBRElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlBRElement {

		[Export ("clear")]
		string Clear { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLBaseElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlBaseElement {

		[Export ("href")]
		string HRef { get; set; }

		[Export ("target")]
		string Target { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLBaseFontElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlBaseFontElement {

		[Export ("color")]
		string Color { get; set; }

		[Export ("face")]
		string Face { get; set; }

		[Export ("size")]
		string Size { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLBodyElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlBodyElement {

		[Export ("aLink")]
		string ALink { get; set; }

		[Export ("background")]
		string Background { get; set; }

		[Export ("bgColor")]
		string BgColor { get; set; }

		[Export ("link")]
		string Link { get; set; }

		[Export ("text")]
		string Text { get; set; }

		[Export ("vLink")]
		string VLink { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLButtonElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlButtonElement {

		[Mac (10,6)]
		[Export ("autofocus")]
		bool Autofocus { get; set; }

		[Export ("disabled")]
		bool Disabled { get; set; }

		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("type")]
		string Type { get; [Mac (10,9)] set; }

		[Export ("value")]
		string Value { get; set; }

		[Mac (10,6)]
		[Export ("willValidate")]
		bool WillValidate { get; }

		[Availability (Introduced = Platform.Mac_10_4, Deprecated = Platform.Mac_10_8)]
		[Export ("accessKey")]
		string AccessKey { get; set; }

		[Mac (10,5)]
		[Export ("click")]
		void Click ();
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLDListElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlDListElement {

		[Export ("compact")]
		bool Compact { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLDirectoryElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlDirectoryElement {

		[Export ("compact")]
		bool Compact { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLDivElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlDivElement {

		[Export ("align")]
		string Align { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLEmbedElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlEmbedElement {

		[Export ("align")]
		string Align { get; set; }

		[Export ("height")]
		int Height { get; set; } /* int, not NSInteger */

		[Export ("name")]
		string Name { get; set; }

		[Export ("src")]
		string Src { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("width")]
		int Width { get; set; } /* int, not NSInteger */
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLFieldSetElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlFieldSetElement {

		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLFontElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlFontElement {

		[Export ("color")]
		string Color { get; set; }

		[Export ("face")]
		string Face { get; set; }

		[Export ("size")]
		string Size { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLFrameElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlFrameElement {

		[Export ("frameBorder")]
		string FrameBorder { get; set; }

		[Export ("longDesc")]
		string LongDesc { get; set; }

		[Export ("marginHeight")]
		string MarginHeight { get; set; }

		[Export ("marginWidth")]
		string MarginWidth { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("noResize")]
		bool NoResize { get; set; }

		[Export ("scrolling")]
		string Scrolling { get; set; }

		[Export ("src")]
		string Src { get; set; }

		[Export ("contentDocument", ArgumentSemantic.Retain)]
		DomDocument ContentDocument { get; }

		[Mac (10,5)]
		[Export ("contentWindow", ArgumentSemantic.Retain)]
		DomAbstractView ContentWindow { get; }

		[Mac (10,5)]
		[Export ("location")]
		string Location { get; set; }

		[Mac (10,5)]
		[Export ("width")]
		int Width { get; } /* int, not NSInteger */

		[Mac (10,5)]
		[Export ("height")]
		int Height { get; } /* int, not NSInteger */
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLFrameSetElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlFrameSetElement {

		[Export ("cols")]
		string Cols { get; set; }

		[Export ("rows")]
		string Rows { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLHRElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlHRElement {

		[Export ("align")]
		string Align { get; set; }

		[Export ("noShade")]
		bool NoShade { get; set; }

		[Export ("size")]
		string Size { get; set; }

		[Export ("width")]
		string Width { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLHeadElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlHeadElement {

		[Export ("profile")]
		string Profile { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLHeadingElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlHeadingElement {

		[Export ("align")]
		string Align { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLHtmlElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlHtmlElement {

		[Export ("version")]
		string Version { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLIFrameElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlIFrameElement {

		[Export ("align")]
		string Align { get; set; }

		[Export ("frameBorder")]
		string FrameBorder { get; set; }

		[Export ("height")]
		string Height { get; set; }

		[Export ("longDesc")]
		string LongDesc { get; set; }

		[Export ("marginHeight")]
		string MarginHeight { get; set; }

		[Export ("marginWidth")]
		string MarginWidth { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("scrolling")]
		string Scrolling { get; set; }

		[Export ("src")]
		string Src { get; set; }

		[Export ("width")]
		string Width { get; set; }

		[Export ("contentDocument", ArgumentSemantic.Retain)]
		DomDocument ContentDocument { get; }

		[Mac (10,6)]
		[Export ("contentWindow", ArgumentSemantic.Retain)]
		DomAbstractView ContentWindow { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLImageElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlImageElement {

		[Export ("name")]
		string Name { get; set; }

		[Export ("align")]
		string Align { get; set; }

		[Export ("alt")]
		string Alt { get; set; }

		[Export ("border")]
		string Border { get; set; }

		[Export ("height")]
		int Height { get; set; } /* int, not NSInteger */

		[Export ("hspace")]
		int HSpace { get; set; } /* int, not NSInteger */

		[Export ("isMap")]
		bool IsMap { get; set; }

		[Export ("longDesc")]
		string LongDesc { get; set; }

		[Export ("src")]
		string Src { get; set; }

		[Export ("useMap")]
		string UseMap { get; set; }

		[Export ("vspace")]
		int VSpace { get; set; } /* int, not NSInteger */

		[Export ("width")]
		int Width { get; set; } /* int, not NSInteger */

		[Mac (10,5)]
		[Export ("complete")]
		bool Complete { get; }

		[Mac (10,5)]
		[Export ("lowsrc")]
		string Lowsrc { get; set; }

		[Mac (10,5)]
		[Export ("naturalHeight")]
		int NaturalHeight { get; } /* int, not NSInteger */

		[Mac (10,5)]
		[Export ("naturalWidth")]
		int NaturalWidth { get; } /* int, not NSInteger */

		[Mac (10,5)]
		[Export ("x")]
		int X { get; } /* int, not NSInteger */

		[Mac (10,5)]
		[Export ("y")]
		int Y { get; } /* int, not NSInteger */

		[Mac (10,5)]
		[Export ("altDisplayString")]
		string AltDisplayString { get; }

		[Mac (10,5)]
		[Export ("absoluteImageURL", ArgumentSemantic.Copy)]
		NSUrl AbsoluteImageUrl { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLLIElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlLIElement {

		[Export ("type")]
		string Type { get; set; }

		[Export ("value")]
		int Value { get; set; } /* int, not NSInteger */
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLLabelElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlLabelElement {

		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }

		[Export ("htmlFor")]
		string HtmlFor { get; set; }

		[Availability (Introduced = Platform.Mac_10_4, Deprecated = Platform.Mac_10_8)]
		[Export ("accessKey")]
		string AccessKey { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLLegendElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlLegendElement {

		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }

		[Export ("align")]
		string Align { get; set; }

		[Availability (Introduced = Platform.Mac_10_4, Deprecated = Platform.Mac_10_8)]
		[Export ("accessKey")]
		string AccessKey { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLLinkElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlLinkElement {

		[Export ("disabled")]
		bool Disabled { get; set; }

		[Export ("charset")]
		string Charset { get; set; }

		[Export ("href")]
		string HRef { get; set; }

		[Export ("hreflang")]
		string HRefLang { get; set; }

		[Export ("media")]
		string Media { get; set; }

		[Export ("rel")]
		string Rel { get; set; }

		[Export ("rev")]
		string Rev { get; set; }

		[Export ("target")]
		string Target { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Mac (10,4)]
		[Export ("sheet", ArgumentSemantic.Retain)]
		DomStyleSheet Sheet { get; }

		[Mac (10,5)]
		[Export ("absoluteLinkURL", ArgumentSemantic.Copy)]
		NSUrl AbsoluteImageUrl { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLMapElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlMapElement {

		[Export ("areas", ArgumentSemantic.Retain)]
		DomHtmlCollection Areas { get; }

		[Export ("name")]
		string Name { get; set; }
	}

	[Mac (10,5)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLMarqueeElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlMarqueeElement {

		[Export ("start")]
		void Start ();

		[Export ("stop")]
		void Stop ();
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLMenuElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlMenuElement {

		[Export ("compact")]
		bool Compact { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLMetaElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlMetaElement {

		[Export ("content")]
		string Content { get; set; }

		[Export ("httpEquiv")]
		string HttpEquiv { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("scheme")]
		string Scheme { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLModElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlModElement {

		[Export ("cite")]
		string Cite { get; set; }

		[Export ("dateTime")]
		string DateTime { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLOListElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlOListElement {

		[Export ("compact")]
		bool Compact { get; set; }

		[Export ("start")]
		int Start { get; set; } /* int, not NSInteger */

		[Export ("type")]
		string Type { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLObjectElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlObjectElement {

		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }

		[Export ("code")]
		string Code { get; set; }

		[Export ("align")]
		string Align { get; set; }

		[Export ("archive")]
		string Archive { get; set; }

		[Export ("border")]
		string Border { get; set; }

		[Export ("codeBase")]
		string CodeBase { get; set; }

		[Export ("codeType")]
		string CodeType { get; set; }

		[Export ("data")]
		string Data { get; set; }

		[Export ("declare")]
		bool Declare { get; set; }

		[Export ("height")]
		string Height { get; set; }

		[Export ("hspace")]
		int HSpace { get; set; } /* int, not NSInteger */

		[Export ("name")]
		string Name { get; set; }

		[Export ("standby")]
		string Standby { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("useMap")]
		string UseMap { get; set; }

		[Export ("vspace")]
		int VSpace { get; set; } /* int, not NSInteger */

		[Export ("width")]
		string Width { get; set; }

		[Export ("contentDocument", ArgumentSemantic.Retain)]
		DomDocument ContentDocument { get; }

		[Mac (10,5)]
		[Export ("absoluteImageURL", ArgumentSemantic.Copy)]
		NSUrl AbsoluteImageUrl { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLOptGroupElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlOptGroupElement {

		[Export ("disabled")]
		bool Disabled { get; set; }

		[Export ("label")]
		string Label { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLOptionElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlOptionElement {

		[Export ("disabled")]
		bool Disabled { get; set; }

		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }

		[Export ("label")]
		string Label { get; set; }

		[Export ("defaultSelected")]
		bool DefaultSelected { get; set; }

		[Export ("selected")]
		bool Selected { get; set; }

		[Export ("value")]
		string Value { get; set; }

		[Export ("text")]
		string Text { get; }

		[Export ("index")]
		int Index { get; } /* int, not NSInteger */
	}

	[Mac (10,4)]
	[BaseType (typeof (DomObject), Name="DOMHTMLOptionsCollection")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlOptionsCollection {

		[Mac (10,5)]
		[Export ("selectedIndex")]
		int SelectedIndex { get; set; } /* int, not NSInteger */

		[Export ("length")]
		uint Length { get; set; } /* unsigned int */

		[Export ("namedItem:")]
		DomNode NamedItem (string name);

		[Mac (10,5)]
		[Export ("add:index:")]
		void Add (DomHtmlOptionElement option, uint /* unsigned int */ index);

		[Mac (10,6)]
		[Export ("remove:")]
		void Remove (uint /* unsigned int */ index);

		[Export ("item:")]
		DomNode GetItem (uint /* unsigned int */ index);
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLParagraphElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlParagraphElement {

		[Export ("align")]
		string Align { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLParamElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlParamElement {

		[Export ("name")]
		string Name { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("value")]
		string Value { get; set; }

		[Export ("valueType")]
		string ValueType { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLPreElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlPreElement {

		[Export ("width")]
		int Width { get; set; } /* int, not NSInteger */

		[Mac (10,5)]
		[Export ("wrap")]
		bool Wrap { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLQuoteElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlQuoteElement {

		[Export ("cite")]
		string Cite { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLScriptElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlScriptElement {

		[Export ("text")]
		string Text { get; set; }

		[Export ("htmlFor")]
		string HtmlFor { get; set; }

		[Export ("event")]
		string Event { get; set; }

		[Export ("charset")]
		string Charset { get; set; }

		[Export ("defer")]
		bool Defer { get; set; }

		[Export ("src")]
		string Src { get; set; }

		[Export ("type")]
		string Type { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLSelectElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlSelectElement {

		[Mac (10,6)]
		[Export ("autofocus")]
		bool Autofocus { get; set; }

		[Export ("disabled")]
		bool Disabled { get; set; }

		[Export ("form", ArgumentSemantic.Retain)]
		DomHtmlFormElement Form { get; }

		[Export ("multiple")]
		bool Multiple { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("size")]
		int Size { get; set; } /* int, not NSInteger */

		[Export ("type")]
		string Type { get; }

		[Export ("options", ArgumentSemantic.Retain)]
		DomHtmlOptionsCollection Options { get; }

		[Export ("length")]
		int Length { get; } /* int, not NSInteger */

		[Export ("selectedIndex")]
		int SelectedIndex { get; set; } /* int, not NSInteger */

		[Export ("value")]
		string Value { get; set; }

		[Mac (10,6)]
		[Export ("willValidate")]
		bool WillValidate { get; }

		[Mac (10,6)]
		[Export ("item:")]
		DomNode GetItem (uint /* unsigned int */ index);

		[Mac (10,6)]
		[Export ("namedItem:")]
		DomNode NamedItem (string name);

		[Mac (10,5)]
		[Export ("add:before:")]
		void Add (DomHtmlElement element, DomHtmlElement before);

		[Export ("remove:")]
		void Remove (int /* int, not NSInteger */ index);
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLStyleElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlStyleElement {

		[Export ("disabled")]
		bool Disabled { get; set; }

		[Export ("media")]
		string Media { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Mac (10,4)]
		[Export ("sheet", ArgumentSemantic.Retain)]
		DomStyleSheet Sheet { get; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLTableCaptionElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlTableCaptionElement {

		[Export ("align")]
		string Align { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLTableCellElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlTableCellElement {

		[Export ("cellIndex")]
		int CellIndex { get; } /* int, not NSInteger */

		[Export ("abbr")]
		string Abbr { get; set; }

		[Export ("align")]
		string Align { get; set; }

		[Export ("axis")]
		string Axis { get; set; }

		[Export ("bgColor")]
		string BgColor { get; set; }

		[Export ("ch")]
		string Ch { get; set; }

		[Export ("chOff")]
		string ChOff { get; set; }

		[Export ("colSpan")]
		int ColSpan { get; set; } /* int, not NSInteger */

		[Export ("headers")]
		string Headers { get; set; }

		[Export ("height")]
		string Height { get; set; }

		[Export ("noWrap")]
		bool NoWrap { get; set; }

		[Export ("rowSpan")]
		int RowSpan { get; set; } /* int, not NSInteger */

		[Export ("scope")]
		string Scope { get; set; }

		[Export ("vAlign")]
		string VAlign { get; set; }

		[Export ("width")]
		string Width { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLTableColElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlTableColElement {

		[Export ("align")]
		string Align { get; set; }

		[Export ("ch")]
		string Ch { get; set; }

		[Export ("chOff")]
		string ChOff { get; set; }

		[Export ("span")]
		int Span { get; set; } /* int, not NSInteger */

		[Export ("vAlign")]
		string VAlign { get; set; }

		[Export ("width")]
		string Width { get; set; }
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLTableElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlTableElement {

		[Export ("caption", ArgumentSemantic.Retain)]
		DomHtmlTableCaptionElement Caption { get; set; }

		[Export ("tHead", ArgumentSemantic.Retain)]
		DomHtmlTableSectionElement THead { get; set; }

		[Export ("tFoot", ArgumentSemantic.Retain)]
		DomHtmlTableSectionElement TFoot { get; set; }

		[Export ("rows", ArgumentSemantic.Retain)]
		DomHtmlCollection Rows { get; }

		[Export ("tBodies", ArgumentSemantic.Retain)]
		DomHtmlCollection TBodies { get; }

		[Export ("align")]
		string Align { get; set; }

		[Export ("bgColor")]
		string BgColor { get; set; }

		[Export ("border")]
		string Border { get; set; }

		[Export ("cellPadding")]
		string CellPadding { get; set; }

		[Export ("cellSpacing")]
		string CellSpacing { get; set; }

		[Export ("frameBorders")]
		string FrameBorders { get; set; }

		[Export ("rules")]
		string Rules { get; set; }

		[Export ("summary")]
		string Summary { get; set; }

		[Export ("width")]
		string Width { get; set; }

		[Export ("createTHead")]
		DomHtmlElement CreateTHead ();

		[Export ("deleteTHead")]
		void DeleteTHead ();

		[Export ("createTFoot")]
		DomHtmlElement CreateTFoot ();

		[Export ("deleteTFoot")]
		void DeleteTFoot ();

		[Export ("createCaption")]
		DomHtmlElement CreateCaption ();

		[Export ("deleteCaption")]
		void DeleteCaption ();

		[Export ("insertRow:")]
		DomHtmlElement InsertRow (int /* int, not NSInteger */ index);

		[Export ("deleteRow:")]
		void DeleteRow (int /* int, not NSInteger */ index);
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLTableRowElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlTableRowElement {

		[Export ("rowIndex")]
		int RowIndex { get; } /* int, not NSInteger */

		[Export ("sectionRowIndex")]
		int SectionRowIndex { get; } /* int, not NSInteger */

		[Export ("cells", ArgumentSemantic.Retain)]
		DomHtmlCollection Cells { get; }

		[Export ("align")]
		string Align { get; set; }

		[Export ("bgColor")]
		string BgColor { get; set; }

		[Export ("ch")]
		string Ch { get; set; }

		[Export ("chOff")]
		string ChOff { get; set; }

		[Export ("vAlign")]
		string VAlign { get; set; }

		[Export ("insertCell:")]
		DomHtmlElement InsertCell (int /* int, not NSInteger */ index);

		[Export ("deleteCell:")]
		void DeleteCell (int /* int, not NSInteger */ index);
	}

	[Mac (10,4)]
	[BaseType (typeof (DomHtmlElement), Name="DOMHTMLTableSectionElement")]
	[DisableDefaultCtor] // ObjCException: +[<TYPE> init]: should never be used
	interface DomHtmlTableSectionElement {

		[Export ("align")]
		string Align { get; set; }

		[Export ("ch")]
		string Ch { get; set; }

		[Export ("chOff")]
		string ChOff { get; set; }

		[Export ("vAlign")]
		string VAlign { get; set; }

		[Export ("rows", ArgumentSemantic.Retain)]
		DomHtmlCollection Rows { get; }

		[Export ("insertRow:")]
		DomHtmlElement InsertRow (int /* int, not NSInteger */ index);

		[Export ("deleteRow:")]
		void DeleteRow (int /* int, not NSInteger */ index);
	}
}

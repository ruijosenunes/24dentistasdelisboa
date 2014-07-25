<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:rssdatehelper="urn:rssdatehelper"
  xmlns:dc="http://purl.org/dc/elements/1.1/"
  xmlns:content="http://purl.org/rss/1.0/modules/content/"
  xmlns:msxml="urn:schemas-microsoft-com:xslt" 
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Examine="urn:Examine" 
  exclude-result-prefixes="msxml umbraco.library Examine "
  xmlns:openSearch="http://a9.com/-/spec/opensearchrss/1.0/"
  xmlns:atom="http://www.w3.org/2005/Atom"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	>


  <xsl:output method="xml" omit-xml-declaration="yes"/>

  <xsl:param name="currentPage"/>

  <!-- Update these variables to modify the feed -->
  <xsl:variable name="RSSNoItems" select="string('3')"/>
  <xsl:variable name="RSSTitle" select="string('Saúde')"/>
  <xsl:variable name="feedURL" select="string('http://services.sapo.pt/rss/feed/saude')"/>
  <xsl:variable name="RSSDescription" select="string('Notícias de saúde')"/>

  <!-- This gets all news and events and orders by updateDate to use for the pubDate in RSS feed -->
  <xsl:variable name="pubDate">
    <xsl:for-each select="$currentPage/* [@isDoc]">
      <xsl:sort select="@createDate" data-type="text" order="descending" />
      <xsl:if test="position() = 1">
        <xsl:value-of select="updateDate" />
      </xsl:if>
    </xsl:for-each>
  </xsl:variable>

  <xsl:template match="/">
    <!-- Check feed is not empty (obviously not required if you're hard-coding the feed as above -->
    <xsl:if test="normalize-space($feedURL)">
        <!-- Assign feed to a variable -->
        <xsl:variable name="rssFeed">
            <xsl:copy-of select="umbraco.library:GetXmlDocumentByUrl($feedURL)"/>
        </xsl:variable>
        <!-- Convert feed variable to a node-set so we can work with it -->
        <xsl:variable name="feedNodeSet" select="msxsl:node-set($rssFeed)"/>

		<h4>Noticias sobre saúde</h4>
		<ul>
        <!-- Loop through each item in the node-set -->
        <xsl:for-each select="$feedNodeSet/rss/channel/item">
            <!-- Output the data, for example the title: -->
			<li><a href="{link}"><xsl:value-of select="title" /></a></li>
        </xsl:for-each>
		</ul>
    </xsl:if>
</xsl:template>
</xsl:stylesheet>
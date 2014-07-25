<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [  <!ENTITY nbsp "&#x00A0;">]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxml="urn:schemas-microsoft-com:xslt" 
	xmlns:umbraco.library="urn:umbraco.library" xmlns:Examine="urn:Examine" 
	exclude-result-prefixes="msxml umbraco.library Examine ">

  <xsl:output method="xml" omit-xml-declaration="yes"/>

  <xsl:param name="currentPage"/>

  <xsl:variable name="minLevel" select="1"/>

  <xsl:template match="/">

    <xsl:if test="$currentPage/@level &gt; $minLevel">
      <ol class="breadcrumb">
        <xsl:for-each select="$currentPage/ancestor::* ">
          <li>
            <a href="{umbraco.library:NiceUrl(@id)}">
              <xsl:value-of select="@nodeName"/>
            </a>
          </li>
        </xsl:for-each>
        <!-- print currentpage -->
        <li>
          <xsl:value-of select="$currentPage/@nodeName"/>
        </li>
      </ol>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
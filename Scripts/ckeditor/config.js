

/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    
    config.extraPlugins = 'panel,dialogui,dialog,pastebase64,clipboard,showborders,tableresize';
    config.filebrowserBrowseUrl = 'javascript:void(0)';  
    //config.readOnly = true;
    config.disableNativeSpellChecker = false;
    //
    config.allowedContent = true; // Disabling advanced content filter in paste event
    //alert(CKEDITOR.version);
    //config.extraPlugins = 'panel,dialogui,dialog,pastefromword,pastebase64,tableresize';
    //,pastebase64,tableresize
    //config.mathJaxLib = '/ckeditor/plugins/mathjax/dialogs/mathjax.js';
    //config.mathJaxLib = '../mathjax-master/es5/latest.js?tex-mml-chtml.js';

    //config.mathJaxLib = 'https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.4/latest.js?config=TeX-MML-AM_CHTML';

   // config.mathJaxLib = 'http://vu-it-jawad/es5/latest.js?config=TeX-MML-AM_CHTML';

};

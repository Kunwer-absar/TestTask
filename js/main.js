//var themecolor = "#B3EB05";
var themecolor = "#f59321";
(function ($) {
    "use strict";

    /*-----------------------------
        Menu Stick
    ---------------------------------*/
    $(window).on('scroll', function () {
        if ($(this).scrollTop() > 1) {
            $('.sticker').addClass("stick");
        }
        else {
            $('.sticker').removeClass("stick");
        }
    });
    jQuery('video').on("loadeddata", function () {
        jQuery('video').attr('controlsList', 'nodownload');
        jQuery('video').bind('contextmenu', function () { return false; });
        jQuery('video').attr('disablePictureInPicture', 'true');
        jQuery('video').attr('disableFullScreen', 'true');
    });
    /*----------------------------
        Toogle Search
    ------------------------------ */
    // Handle click on toggle search button
    $('.header-search').on('click', function () {
        $('.search').toggleClass('open');
        return false;
    });

    /*----------------------------
        jQuery MeanMenu
    ------------------------------ */
  

    jQuery('nav#dropdown').meanmenu();

    $(document).ready(function () {
        // executes when HTML-Document is loaded and DOM is ready
       
        
        
    
       
        // breakpoint and up  
        $(window).resize(function () {
            if ($(window).width() >= 980) {

                // when you hover a toggle show its dropdown menu
                $(".navbar .dropdown-toggle").hover(function () {
                    $(this).parent().toggleClass("show");
                    $(this).parent().find(".dropdown-menu").toggleClass("show");
                });

                // hide the menu when the mouse leaves the dropdown
                $(".navbar .dropdown-menu").mouseleave(function () {
                    $(this).removeClass("show");
                });

                // do something here
            }
        });

        HideAllDivs();

        // document ready  
    });
    $(window).scroll(function () {
        var top = $(window).scrollTop();
        if (top >= 100) {
            $("#small-logo-li").css("display", "block");
            $("#small-logo-li").css("margin-top", "0.22rem");
            $("#menu").css("margin-top", "0.6rem");

        }
        else {
            $("#small-logo-li").css("display", "none");
            $("#menu").css("margin-top", "0rem");
        }
    });


    /*----------------------------
        Nivo Slider Active
    ------------------------------ */
    $('#nivoslider').nivoSlider({
        effect: 'random',
        slices: 15,
        boxCols: 10,
        boxRows: 10,
        animSpeed: 500,
        pauseTime: 5000,
        startSlide: 0,
        directionNav: true,
        controlNavThumbs: false,
        pauseOnHover: false,
        manualAdvance: true
    });
    /*----------------------------
        Wow js active
    ------------------------------ */
    new WOW().init();

    /*--------------------------
        ScrollUp
    ---------------------------- */
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });

    /*--------------------------
        Counter Up
    ---------------------------- */
    $('.counter').counterUp({
        delay: 70,
        time: 1000
    });

    /*--------------------------------
        Testimonial Slick Carousel
    -----------------------------------*/
    $('.testimonial-text-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        draggable: false,
        fade: true,
        asNavFor: '.slider-nav'
    });
    /*------------------------------------
        Testimonial Slick Carousel as Nav
    --------------------------------------*/
    $('.testimonial-image-slider').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.testimonial-text-slider',
        dots: false,
        arrows: true,
        centerMode: true,
        focusOnSelect: true,
        centerPadding: '10px',
        responsive: [
            {
                breakpoint: 450,
                settings: {
                    dots: false,
                    slidesToShow: 3,
                    centerPadding: '0px',
                }
            },
            {
                breakpoint: 420,
                settings: {
                    autoplay: true,
                    dots: false,
                    slidesToShow: 1,
                    centerMode: false,
                }
            }
        ]
    });

    /*------------------------------------
        Testimonial Slick Carousel
    --------------------------------------*/
    $('.testimonial-carousel').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        dots: true,
    });

    /*------------------------------------
        Textilate Activation
    --------------------------------------*/
    $('.tlt').textillate({
        loop: true,
        minDisplayTime: 2500
    });

    /*------------------------------------
        Video Player
    --------------------------------------*/
    $(".player").YTPlayer({
        showControls: false
    });

    $(".player-small").YTPlayer({
        showControls: true
    });

    /*------------------------------------
        MailChimp
    --------------------------------------*/
    $('#mc-form').ajaxChimp({
        language: 'en',
        callback: mailChimpResponse,
        // ADD YOUR MAILCHIMP URL BELOW HERE!
        url: 'http://themeshaven.us8.list-manage.com/subscribe/post?u=759ce8a8f4f1037e021ba2922&amp;id=a2452237f8'
    });

    function mailChimpResponse(resp) {

        if (resp.result === 'success') {
            $('.mailchimp-success').html('' + resp.msg).fadeIn(900);
            $('.mailchimp-error').fadeOut(400);

        } else if (resp.result === 'error') {
            $('.mailchimp-error').html('' + resp.msg).fadeIn(900);
        }
    }

    /*------------------------------------
        ColorSwitcher
    --------------------------------------*/
    $('.ec-handle').on('click', function () {
        $('.ec-colorswitcher').trigger('click')
        $(this).toggleClass('btnclose');
        $('.ec-colorswitcher').toggleClass('sidebarmain');
        return false;
    });
    $('.ec-boxed,.pattren-wrap a,.background-wrap a').on('click', function () {
        $('.as-mainwrapper').addClass('wrapper-boxed');
        $('.as-mainwrapper').removeClass('wrapper-wide');
    });
    $('.ec-wide').on('click', function () {
        $('.as-mainwrapper').addClass('wrapper-wide');
        $('.as-mainwrapper').removeClass('wrapper-boxed');
    });

/*------------------------------------
	Magnific Popup Active
--------------------------------------*/
$('.popup-image').magnificPopup({
  type: 'image',
  gallery:{
            enabled:true
        }
  // other options
});

$('.popup-youtube').magnificPopup({
    type: 'iframe'
});
    
    
})(jQuery); 
window.onscroll = function () { myFunction() };

function myFunction() {
    var winScroll = document.body.scrollTop || document.documentElement.scrollTop;
    var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    var scrolled = (winScroll / height) * 100;
    document.getElementById("myBar").style.width = scrolled + "%";
}
(function ($) {
    "use strict";

    // manual carousel controls
    $('.next').click(function () { $('.carousel').carousel('next'); return false; });
    $('.prev').click(function () { $('.carousel').carousel('prev'); return false; });

})(jQuery);

function writetext(text, text1) {

    var tooltip = document.getElementById('myTooltip');
    tooltip.style.display = 'block';
    tooltip.innerHTML = text;
}


function HideAllDivs()
{
    $('#tiles_KPK').hide();
    $('#tiles_AJK').hide();
    $('#tiles_Punjab').hide();
    $('#tiles_Sindh').hide();
    $('#tiles_Blouchistan').hide();
    $('#tiles_Capital').hide();
    $('#tiles_Gilgit').hide();
}
function hover(content) {
    var ajkimg = 'img/provinceimages/AJKflag.jpg';
    var pdiv = +$('#tiles');
    var gilimg = 'img/provinceimages/pak-china-border.jpeg';
    var blouchimg ='img/provinceimages/ziarat.jpg';
    var punimg ='img/provinceimages/badshahimosque.jpg';
    var sindhimg ='img/provinceimages/quaidtomb2.jpg';
    var kpkimg = 'img/provinceimages/kyberpass.jpg';
    var darrow = 'img/icon/down-arrow.png'
    var CAJK = 'AJK'
    var CPUNJ = 'Punj'

    HideAllDivs();



    if (content === 'CAPITAL') {
        $('#tiles_Capital').show();
    }
    else if (content === 'PUNJAB') {
       
        $('#tiles_Punjab').show();
       
     
        
    }
    else if (content === 'GILGIT') {
        $('#tiles_Gilgit').show();
      

    }
    else if (content === 'BLOUCHISTAN') {
        $('#tiles_Blouchistan').show();
    }
    else if (content === 'AJK') {
       
        $('#tiles_AJK').show();
        

    }
    else if (content === 'SINDH') {
      $('#tiles_Sindh').show();
       
    }
    else if (content === 'KPK') {
        $('#tiles_KPK').show();
       
    }
    else {
       
    }
  
}



$(function () {

    var owl = $('.slide-one-item');

    

    $('.thumbnail li').each(function (slide_index) {
        $(this).click(function (e) {
            owl.trigger('to.carousel', [slide_index, 1500]);
            e.preventDefault();
        })
    })

    owl.on('changed.carousel', function (event) {
        $('.thumbnail li').removeClass('active');
        $('.thumbnail li').eq(event.item.index - 2).addClass('active');
    })


})
function slider(content) {
    var a = content;

    if (a === '1')
    {
        slidesToShow(id='1');
    }
}

function menuouthover1() {
    $('#facultiesname').hide();
    
   
}
function menuouthover() {
    
    $('#schlarship').hide();
}
//

// menu active-inactive
function onHover(content) {
    if (content === 'QA') { $('#QA').attr('src', 'img/whyvu/colorPNG/Education.png'); }
    else if (content === 'Globe') {$('#Globe').attr('src', '');}
    else if (content === 'IT') { $('#IT').attr('src', '');}
    else if (content === 'AFF') {$('#AFF').attr('src', '');}
}

function offHover(content) {
    if (content === 'QA')
        $('#QA').attr('src', 'img/whyvu/PNG/Education.png');
    else if (content === 'Globe')
        $('#Globe').attr('src', 'img/whyvu/PNG/Globe.png');
    else if (content === 'IT')
        $('#IT').attr('src', 'img/whyvu/PNG/PC.png');
    else if (content === 'AFF')
        $('#AFF').attr('src', 'img/whyvu/PNG/$.png');
    }
    //$(function () {
    //    $('#CGlobe').hover(function () {
    //        $('#Gtext').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //        $('#Gtext').css('color', 'white');
    //    });
    //});

    //$(function () {
    //    $('#CIT').hover(function () {
    //        $('#ITtext').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //        $('#ITtext').css('color', 'white');
    //    });
    //});
    //$(function () {
    //    $('#CQA').hover(function () {
    //        $('#QAtext').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //        $('#QAtext').css('color', 'white');
    //    });
    //});
    //$(function () {
    //    $('#CAFF').hover(function () {
    //        $('#AFFtext').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //        $('#AFFtext').css('color', 'white');
    //    });
    //});
    //$(function () {
    //    $('#DP').hover(function () {
    //        $('#DPH').css('color', themecolor);
    //        $('#DPH1').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //            $('#DPH').css('color', 'white');
    //            $('#DPH1').css('color', 'white');
    //    });
    //});
    //$(function () {
    //    $('#CA').hover(function () {
    //        $('#CAH').css('color', themecolor);
    //        $('#CAH1').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //        $('#CAH').css('color', 'white');
    //        $('#CAH1').css('color', 'white');
    //    });
    //});
    //$(function () {
    //    $('#AS').hover(function () {
    //        $('#ASH').css('color', themecolor);
    //        $('#ASH1').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //        $('#ASH').css('color', 'white');
    //        $('#ASH1').css('color', 'white');
    //    });
    //});

    //$(function () {
    //    $('#TG').hover(function () {
    //        $('#TGH').css('color', themecolor);
    //        $('#TGH1').css('color', themecolor);
    //    }, function () {
    //        // on mouseout, reset the background colour
    //        $('#TGH').css('color', 'white');
    //        $('#TGH1').css('color', 'white');
    //    });
    //});
    $(function () {
        $('#PCP').hover(function () {
            $('#link').remove('href', '');
            var url = $('#link').attr('href', 'https://citizenportal.gov.pk/');

        });
    });
    $(function () {
        $('.imp').hover(function () {
            $('#link').remove('href', '');
            var url = $('#link').attr('href', '/PhotoGallery/ImportantLinks');

        });
    });

    $(function () {
        $('#DR').hover(function () {
            $('#DR').addClass('active');
            $('#DR1').removeClass('active');
            $('#DR2').removeClass('active');
            $('#DR3').removeClass('active');
            $('#DR4').removeClass('active');
            $('#DR5').removeClass('active');
        });
    });
    $(function () {
        $('#DR1').hover(function () {
            $('#DR1').addClass('active');
            $('#DR').removeClass('active');
            $('#DR2').removeClass('active');
            $('#DR3').removeClass('active');
            $('#DR4').removeClass('active');
            $('#DR5').removeClass('active');
        });
    });
    $(function () {
        $('#DR2').hover(function () {
            $('#DR2').addClass('active');
            $('#DR').removeClass('active');
            $('#DR1').removeClass('active');
            $('#DR3').removeClass('active');
            $('#DR4').removeClass('active');
            $('#DR5').removeClass('active');
        });
    });
    $(function () {
        $('#DR3').hover(function () {
            $('#DR3').addClass('active');
            $('#DR').removeClass('active');
            $('#DR1').removeClass('active');
            $('#DR2').removeClass('active');
            $('#DR4').removeClass('active');
            $('#DR5').removeClass('active');
        });
    });
    $(function () {
        $('#DR4').hover(function () {
            $('#DR4').addClass('active');
            $('#DR').removeClass('active');
            $('#DR1').removeClass('active');
            $('#DR2').removeClass('active');
            $('#DR3').removeClass('active');
            $('#DR5').removeClass('active');
        });
    });
    $(function () {
        $('#DR5').hover(function () {
            $('#DR5').addClass('active');
            $('#DR').removeClass('active');
            $('#DR1').removeClass('active');
            $('#DR2').removeClass('active');
            $('#DR3').removeClass('active');
            $('#DR4').removeClass('active');
        });
    });
    $(function () {
        $('#DR6').hover(function () {
            $('#DR6').addClass('active');
            $('#DR').removeClass('active');
            $('#DR1').removeClass('active');
            $('#DR2').removeClass('active');
            $('#DR3').removeClass('active');
            $('#DR4').removeClass('active');
            $('#DR5').removeClass('active');
        });
    });
    function erase() {
        $('#DR').removeClass('active');
        $('#DR1').removeClass('active');
        $('#DR2').removeClass('active');
        $('#DR3').removeClass('active');
        $('#DR4').removeClass('active');
        $('#DR5').removeClass('active');
        $('#DR6').removeClass('active');
        $('#facultiesname').hide();
        $('#schlarship').hide();
        $('#link').attr('href', '');

    }

    function hovermenu(e) {

        refreshmainmenu();
        var valueOfInput = document.getElementById(e);
        $(valueOfInput).addClass('activemainmenu');

        //id.addClass('active1');
    }
    function refreshmainmenu() {

        $('#navbarDropdown1').removeClass('activemainmenu');
        $('#navbarDropdown2').removeClass('activemainmenu');
        $('#navbarDropdown3').removeClass('activemainmenu');
        $('#navbarDropdown4').removeClass('activemainmenu');
        $('#navbarDropdown5').removeClass('activemainmenu');
        $('#navbarDropdown6').removeClass('activemainmenu');
        $('#navbarDropdown7').removeClass('activemainmenu');


    }
    function refreshsubmenu() {

        $('.selected').removeClass('activesubmenu');

    }
    $(function () {
        $('.selected').hover(function () {
            $('.selected').removeClass('activesubmenu');
            $(this).addClass('activesubmenu');



        });
    });

    $(function () {
        $('.activesubsubmenu').hover(function () {
            $('.activesubsubmenu').removeClass('activesubsubmenu');
            $(this).addClass('activesubsubmenu');



        });
    });
    $(function () {
        $('.dropdown-menu').mouseleave(function () {
            $('.selected').removeClass('activesubmenu');



        });
    });


    function myFunctionAJK() {

        var x = document.getElementById("AJK");

        if (x.style.display === "block") {
            x.style.display = "none";
            document.getElementById("AJKimg").src = "img/icon/down-arrow.png";
        }
        else {
            x.style.display = "block";
            document.getElementById("AJKimg").src = "img/icon/up-arrow.png";

        }
    }

    function myFunctionpunjab() {
        var x = document.getElementById("Punj");

        if (x.style.display === "block") {
            x.style.display = "none";
            document.getElementById("Pimg").src = "img/icon/down-arrow.png";



        }
        else {
            x.style.display = "block";
            document.getElementById("Pimg").src = "img/icon/up-arrow.png";





        }
    }
    function myFunctionsindh() {
        var x = document.getElementById("sind");

        if (x.style.display === "block") {
            x.style.display = "none";
            document.getElementById("Simg").src = "img/icon/down-arrow.png";
        }
        else {
            x.style.display = "block";
            document.getElementById("Simg").src = "img/icon/up-arrow.png";



        }
    }
    function myFunctionbaloch() {
        var x = document.getElementById("baloch");

        if (x.style.display === "block") {
            x.style.display = "none";
            document.getElementById("Bimg").src = "img/icon/down-arrow.png";
        }
        else {
            x.style.display = "block";
            document.getElementById("Bimg").src = "img/icon/up-arrow.png";



        }
    }
    function myFunctionGBT() {
        var x = document.getElementById("GBT");

        if (x.style.display === "block") {
            x.style.display = "none";
            document.getElementById("GBimg").src = "img/icon/down-arrow.png";
        }
        else {
            x.style.display = "block";
            document.getElementById("GBimg").src = "img/icon/up-arrow.png";

        }
    }
    function myFunctionKPK() {
        var x = document.getElementById("KPK");

        if (x.style.display === "block") {
            x.style.display = "none";
            document.getElementById("KPKimg").src = "img/icon/down-arrow.png";
        }
        else {
            x.style.display = "block";
            document.getElementById("KPKimg").src = "img/icon/up-arrow.png";

        }
    }
    (function (d, b, e) { var c = d("html, body"); d.CBPNTAccordion = function (f, g) { this.$el = d(g); this._init(f) }; d.CBPNTAccordion.defaults = {}; d.CBPNTAccordion.prototype = { _init: function (f) { this.options = d.extend(true, {}, d.CBPNTAccordion.defaults, f); this._config(); this._initEvents() }, _config: function () { this.$items = this.$el.find(".cbp-nttrigger") }, _initEvents: function () { this.$items.on("click.cbpNTAccordion", function () { var f = d(this).parent(); if (f.hasClass("cbp-ntopen")) { f.removeClass("cbp-ntopen") } else { f.addClass("cbp-ntopen"); c.scrollTop(f.offset().top - 80) } }) }, destroy: function () { this.$items.off(".cbpNTAccordion").parent().removeClass("cbp-ntopen") } }; var a = function (f) { if (b.console) { b.console.error(f) } }; d.fn.cbpNTAccordion = function (g) { if (typeof g === "string") { var f = Array.prototype.slice.call(arguments, 1); this.each(function () { var h = d.data(this, "cbpNTAccordion"); if (!h) { a("cannot call methods on cbpNTAccordion prior to initialization; attempted to call method '" + g + "'"); return } if (!d.isFunction(h[g]) || g.charAt(0) === "_") { a("no such method '" + g + "' for cbpNTAccordion instance"); return } h[g].apply(h, f) }) } else { this.each(function () { var h = d.data(this, "cbpNTAccordion"); if (h) { h._init() } else { h = d.data(this, "cbpNTAccordion", new d.CBPNTAccordion(g, this)) } }) } return this } })(jQuery, window);
    $(function () {
        $('.heading-fac').click(function () {
            $('.heading-fac').removeClass('active-heading-fac');
            $(this).addClass('active-heading-fac');




        });
    });
    var valternate = $.noConflict();

    function initializeAccordions() {
        valternate(".accordion-item").each(function (key, value) {
            var panelID = valternate(this).data("panel-id");
            if (panelID) {
                var valternateaccordionItemPanel;
                if (panelID.indexOf("#") !== -1)
                { valternateaccordionItemPanel = valternate(panelID) }
                else
                { valternateaccordionItemPanel = valternate("#" + panelID) }
                if (valternate(this).hasClass("active"))
                { valternateaccordionItemPanel.addClass("active") }
            }
        });
        valternate(".accordion-panel").each(function () {
            if (!valternate(this).hasClass("active"))
            { valternate(this).css("height", "0px") }
            else { valternate(this).css("height", valternate(this).prop("scrollHeight") + "px") }
        })
    }
    valternate(document).ready(function () {
        initializeAccordions(); valternate("body").on("click", ".accordion-item", function (e) {
            var panelID = valternate(this).data("panel-id"); if (panelID) {
                var valternateaccordionItemPanel;
                if (panelID.indexOf("#") !== -1)
                { valternateaccordionItemPanel = valternate(panelID) }
                else
                { valternateaccordionItemPanel = valternate("#" + panelID) }
                if (!valternateaccordionItemPanel.hasClass("active")) {
                    var accrPanelHeight = valternateaccordionItemPanel[0].scrollHeight; valternateaccordionItemPanel.addClass("active");
                    valternateaccordionItemPanel.animate({ height: accrPanelHeight + "px" }, 250, function ()
                    { valternateaccordionItemPanel.css("height", "auto"); valternateaccordionItemPanel.css("min-height", accrPanelHeight + "px") });
                    valternate(this).addClass("active")
                }
                else {
                    valternateaccordionItemPanel.removeClass("active");
                    valternateaccordionItemPanel.animate({ height: "0px" }, 250, function ()
                    { valternateaccordionItemPanel.css("min-height", "0px") });
                    valternate(this).removeClass("active");
                    valternateaccordionItemPanel.css("min-height", "0px")
                }
            }
        })
    })

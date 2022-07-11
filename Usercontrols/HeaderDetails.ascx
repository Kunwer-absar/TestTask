<%@ Control Language="VB" AutoEventWireup="false" CodeFile="HeaderDetails.ascx.vb" Inherits="Usercontrols_HeaderDetailsascx" %>
<link rel="shortcut icon" type="image/x-icon" href="/img/logo.png" />

<script>

    String.prototype.replaceAll = function (str1, str2, ignore) {
        return this.replace(new RegExp(str1.replace(/([\/\,\!\\\^\$\{\}\[\]\(\)\.\*\+\?\|\<\>\-\&])/g, "\\$&"), (ignore ? "gi" : "g")), (typeof (str2) == "string") ? str2.replace(/\$/g, "$$$$") : str2);
    }

    String.prototype.toTitleCase = function () {
        var input;
        var lowers = ["of", "&", "and", "in", "by", "towards", "on", "with", "online"];
        var ignore = ["it", "the", "to", "option", "ii", "iii", "iv", "v", "mcs", "bs", "mba", "msba", "mit", "mb", "m.com", "b.com", "b.a", "b.sc", "mpa", "bs-ba", "vu", "ms", "mscs", "for", "s", "hec", "http", "www", "usaid", "hrm", "that", "need", "be", "Pksig", "pbm", "please", "having", "atleast", "msba"];


        input = this.replaceAll('>', '> ');
        input = input.replaceAll('<', ' <');
        input = input.replaceAll(':', ' :');
        input = input.replaceAll('(', '( ');
        input = input.replaceAll(')', ' )');
        input = input.replaceAll(';', '; ');
        input = input.replaceAll('.', ' .');
        input = input.replaceAll('.', '. ');
        input = input.replaceAll('/', '/ ');
        input = input.replaceAll('-', '- ');
        input = input.replaceAll('-', ' -');


        result = input.split(' ');
        result = result.map(function (word) {
            if (ignore.indexOf(word.toLowerCase()) > -1) {
                return word;
            }
            else {
                return (lowers.indexOf(word.toLowerCase()) > -1) ? word.toLowerCase() : capitalize(word);
            }

        })

        result = result.join(' ');

        result = result.replaceAll(' :', ':');
        result = result.replaceAll('> ', '>');
        result = result.replaceAll(' <', '<');
        result = result.replaceAll('( ', '(');
        result = result.replaceAll(' )', ')');
        result = result.replaceAll('; ', ';');
        result = result.replaceAll(' .', '.');
        result = result.replaceAll('. ', '.');
        result = result.replaceAll('/ ', '/');
        result = result.replaceAll('- ', '-');
        result = result.replaceAll(' -', '-');


        return result;
    };


    function capitalize(s) {
        return s.charAt(0).toUpperCase() + s.slice(1).toLowerCase();
    }

    function CapitalizeAllHeadings() {

        $(".head1").each(function () {
            $(this).html($(this).html().toTitleCase());
        });

        $(".head2").each(function () {
            $(this).html($(this).html().toTitleCase());
        });

        $(".head3").each(function () {
            $(this).html($(this).html().toTitleCase());
        });


        $(".head4").each(function () {
            $(this).html($(this).html().toTitleCase());
        });

    }

</script>


<script src="/Scripts/jquery-3.6.0.min.js"></script>

<script type="text/javascript" language="javascript">
    $(document).ready(function () {

        facebook.src = '/switcher/Themes/' + selectedColor + '/Footericons/Facebookiconcolor.jpg';
        twitter.src = '/switcher/Themes/' + selectedColor + '/Footericons/Twittericoncolor.jpg';
        yt.src = '/switcher/Themes/' + selectedColor + '/Footericons/Youtubeiconcolor.jpg';
        ins.src = '/switcher/Themes/' + selectedColor + '/Footericons/Instagram-color.png';
        lin.src = '/switcher/Themes/' + selectedColor + '/Footericons/linkedincolor.png';
        /*  PopulationGallery.src = '/switcher/Themes/' + selectedColor + '/PVCicons/images.png';*/
        //for (let i = 0; i < Population.length; i++) {
        //    var path = '/switcher/Themes/' + selectedColor + '/PVCicons/images.png';
        //    Population[i].setAttribute("src", '/switcher/Themes/' + selectedColor + '/PVCicons/images.png');
        //}
        /*Population.src = '/switcher/Themes/' + selectedColor + '/PVCicons/images.png';*/

        CapitalizeAllHeadings();
    });
</script>



<%--<div class="sitemap container1 ">
    <!--#include file="~/SiteMap.inc"-->
</div>--%>
<!--End of Header Area-->
<!--Slider Area Start-->
<!-- 16:9 aspect ratio -->
<div id="Banner" runat="server" class="background-area img-fluid fixed-bg-1 pt-110 pb-110 overlay-light-2-fullwidth" style="background: url('../../img/banner/Cs&ITbanner.jpg'); background-size: cover; background-position: right; background-repeat: no-repeat;">
    <div class="banner-content">
        <div class="container1">
            <div class="row">
                <div class="col-md-7">
                    <div class="text-content-wrapper text-center full-width">
                        <div id="divPageHeading" runat="server" class="text-content">
                            <h1 class="title1  mb-20">
                                <asp:Label ID="lblPageTitle" CssClass="tlt block" data-in-effect="fadeInRight" data-out-effect="" runat="server"></asp:Label>

                            </h1>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="about-page-area section-padding sidecolor">
    <div class="container containermarginleft bodyContentContainer">

        <div class="row">
            <div class="col-lg-12 col-md-12 col-12">
                
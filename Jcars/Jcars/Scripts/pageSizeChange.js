$(document).on('change', '.pro_pag_tf1', function (e) {
    var pageSize = this.options[e.target.selectedIndex].text
    window.location.href = "/Car/Index?pageSize=" + pageSize;
});
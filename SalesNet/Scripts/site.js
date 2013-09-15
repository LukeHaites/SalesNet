$(document).ready(function () {
  $("#tabs").tabs();

  $("body").on("click", ".showdets", function () {
    $(this).closest("tr").next("tr").find("div").slideDown(200);
  });

  $("body").on("click", ".hidedets", function () {
    $(this).closest("tr").find("div").slideUp(200);
  });
});

$(document).ready(function () {
  $("#tabs").on("click", function() {
    var active = $("#tabs").tabs("option", "active");
    alert(active);
  });
});
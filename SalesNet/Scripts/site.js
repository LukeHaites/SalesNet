$(document).ready(function () {
  $("body").on("click", ".showdets", function () {
      $(this).closest("tr").next("tr").find("div").slideToggle(200);
      $(this).toggleClass("ui-icon-triangle-1-s");
      $(this).toggleClass("ui-icon-triangle-1-n");
  });
});
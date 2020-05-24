var $j = jQuery.noConflict();
$j(document).ready(function () {
    var archiveData = JSON.parse($j('#hdfArchive').val());
    var treeArr = [];
    for (var i = 0; i < archiveData.length; i++) {
        var treeElement = {
            text: archiveData[i].year,
            icon: "glyphicon glyphicon-time",
            selectedIcon: "glyphicon glyphicon-time",
            color: "#000000",
            backColor: "#FFFFFF",
            href: "#node-1",
            selectable: i == 0 ? true : false,
            state: {
                checked: i == 0 ? true : false,
                disabled: false,
                expanded: i == 0 ? true : false,
                selected: i == 0 ? true : false
            },
            tags: [archiveData[i].count],
            nodes: []
        };
        for (var j = 0; j < archiveData[i].blogs.length; j++) {
            treeElement.nodes.push({
                text: archiveData[i].blogs[j].title,
                href: "/Blog/Details/" + archiveData[i].blogs[j].id,
                icon: "glyphicon glyphicon-list-alt"
            });
        }
        treeArr.push(treeElement);
    }


    $j('#tree').treeview({
        data: treeArr,
        enableLinks: true,
        showTags: true,
        selectedBackColor: "#f6f8fa",
        selectedColor: "#e96546",
        showBorder: false,
        expandIcon: "",
        collapseIcon: ""
    });
    
});
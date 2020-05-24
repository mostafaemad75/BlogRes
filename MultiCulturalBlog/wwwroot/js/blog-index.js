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
                icon: "glyphicon glyphicon-list-alt",
                nodeId: archiveData[i].blogs[j].id
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

  

    setSelectedChildern();
    function setSelectedChildern() {
        var nodeId = $j('#btnEdit').data('id');
        if (nodeId != null) {
            $j.each(getAllNodes(), function (index, item) {
                if (item.href == "/Blog/Details/" + nodeId) {
                    var parent = $j('#tree').treeview('getParent', item);
                    $j('#tree').treeview('toggleNodeSelected', [item.nodeId, { silent: true }]);
                    $j('#tree').treeview('expandNode', [parent.nodeId, { silent: true, ignoreChildren: false }]);
                    collabseSiblings(parent);
                   
                    return false;
                }
            });
        }
    }
    $j('#tree').on('nodeExpanded', function (event, data) {
        collabseSiblings(data);
    });
    function getAllNodes() {
        
        var treeViewObject = $j('#tree').data('treeview'),
            allCollapsedNodes = treeViewObject.getCollapsed(),
            allExpandedNodes = treeViewObject.getExpanded(),
            allNodes = allCollapsedNodes.concat(allExpandedNodes);

        return allNodes;
    }

    function collabseSiblings(node) {
        var $siblings = $j('#tree').treeview('getSiblings', node);
        $j.each($siblings, function (index, item) {
            $j('#tree').treeview('collapseNode', [item.nodeId, { silent: true, ignoreChildren: false }]);
        });
    }
});
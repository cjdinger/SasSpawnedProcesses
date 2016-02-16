proc iomoperate uri=&connection.;
    list spawned out=spawned;
quit;

data _null_;
    set spawned;
    length y $ 3;
    y = put(_n_,z3.);
    x = dosubl("
    proc iomoperate uri=&connection. launched='" || serverid || "';
    list attrs cat='Information' out=pids" || y || ";
    quit;
    data pids" || y || ";
    set pids" || y || ";
    length sname $30;
    sname = substr(name,find(name,'.')+1);
    run;

    proc transpose data=work.pids" || y || "
    out=work.tpids" || y || "
    ;
    id sname;
    var value;
    run;
    ");
run;

data _allpids_;
    set tpids:;
    length StartTime 8;
    format StartTime datetime20.;
    starttime = input(UpTime,anydtdtm19.);
run;

proc datasets lib=work nolist;
delete tpids:;
delete spawned;
quit;
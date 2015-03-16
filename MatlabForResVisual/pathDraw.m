clf

ax = axes('XLim',[-10 10],'YLim',[-10 10],'ZLim',[-10 10]);
view(3);
grid on;
axis equal

[xc yc zc] = cylinder([0.1 0.0]);


h(1) = surface( xc,         zc,         -yc, 'FaceColor', 'red');
    
t = hgtransform('Parent',ax);
set(h,'Parent',t)

set(gcf,'Renderer', 'opengl')

drawnow

lon = x(1:end);
dummy = y(1:end);
lat = z(1:end);
rotx = xr(1:end);
roty = yr(1:end);
rotz = zr(1:end);

xlabel('x');
ylabel('y');
zlabel('z');
% hold on;

for i = 1:numel(lon)
    
    trans = makehgtform('translate',[lon(i) dummy(i) lat(i)]);
    rotax = makehgtform('xrotate', rotx(i));
    rotay = makehgtform('yrotate', roty(i));
    rotaz = makehgtform('zrotate', rotz(i));
    set(t,'Matrix', trans*rotax*rotay*rotaz); 
    if i >= 2
        %line(lon(i+1),lat(i+1));
        line([lon(i) lon(i-1)], [dummy(i) dummy(i-1)],[lat(i) lat(i-1)]);
    end
    %set(t,'Matrix', trans*rotay);
    %set(t,'Matrix', trans*rotaz);
    pause%(0.001);
    trans = makehgtform('translate',[0 0 0]);
    rotax = makehgtform('xrotate', 0);
    rotay = makehgtform('yrotate', 0);
    rotaz = makehgtform('zrotate', 0);
    set(t,'Matrix', trans*rotax*rotay*rotaz); 
    pause
end
    